// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public class MapDrawer
    {
        public enum View
        {
            Top, // X right, Y down
            Front, // X right, Z up
            Side // Y right, Z up
        }

        public MapDrawer(UnrealMap map)
        {
            this.map = map;
            zoom = Double.NaN;
        }

        private UnrealMap map;
        private double zoom; // used by the UI for dragging

        public double PixelsPerUnit => zoom;

        public void DrawLayout(Graphics gfx, int width, int height,
            View view, UnrealMap importantMap = null, UnrealMap draggedMap = null)
        {
            if (map.BrushCount == 0)
                return; // nothing to be drawn

            // Variables
            double halfWidth = width / 2.0;
            double halfHeight = height / 2.0;
            double xMin = map.Brushes.Min(b => view != View.Side ? b.GetXMin() : b.GetYMin());
            double xMax = map.Brushes.Max(b => view != View.Side ? b.GetXMax() : b.GetYMax());
            double yMin = map.Brushes.Min(b => view == View.Top ? b.GetYMin() : -b.GetZMax());
            double yMax = map.Brushes.Max(b => view == View.Top ? b.GetYMax() : -b.GetZMin());
            double xMid = (xMin + xMax) / 2.0; // at the center of the display
            double yMid = (yMin + yMax) / 2.0; // at the center of the display
            double xRan = xMax - xMin;
            double yRan = yMax - yMin;
            zoom = Math.Min(width / xRan, height / yRan) * 0.99; // pixels per world unit, set to 'Fill' mode
            var solidPen = new Pen(new SolidBrush(Color.FromArgb(64, 64, 255)));
            var semiSolidPen = new Pen(new SolidBrush(Color.FromArgb(255, 128, 0)));
            var nonSolidPen = new Pen(new SolidBrush(Color.FromArgb(0, 255, 0)));
            var subtractPen = new Pen(new SolidBrush(Color.FromArgb(255, 255, 0)));
            var moverPen = new Pen(new SolidBrush(Color.FromArgb(255, 0, 255)));
            var unknownPen = new Pen(new SolidBrush(Color.FromArgb(128, 128, 128)));
            var actorPen = new Pen(new SolidBrush(Color.FromArgb(0, 255, 255)));
            var importantPen = new Pen(new SolidBrush(Color.FromArgb(0, 224, 224, 224)));
            var draggedPen = new Pen(new SolidBrush(Color.FromArgb(0, 192, 192, 192)));
            draggedPen.DashPattern = new float[] { 1f, 1f };

            gfx.Clear(Color.Black);

            // Draw brushes
            foreach (var brush in map.Brushes)
            {
                // Determine pen to use
                Pen usedPen;
                if (brush.Owner == importantMap)
                    usedPen = importantPen;
                else if (brush.Owner == draggedMap)
                    usedPen = draggedPen;
                else
                    switch (brush.Operation)
                    {
                        case BrushOperation.Solid: usedPen = solidPen; break;
                        case BrushOperation.SemiSolid: usedPen = semiSolidPen; break;
                        case BrushOperation.NonSolid: usedPen = nonSolidPen; break;
                        case BrushOperation.Subtract: usedPen = subtractPen; break;
                        case BrushOperation.Mover: usedPen = moverPen; break;
                        default: usedPen = unknownPen; break;
                    }

                // Draw edges
                foreach (var edge in brush.Edges)
                {
                    Project(edge.Point1, view, out double x1, out double y1);
                    Project(edge.Point2, view, out double x2, out double y2);
                    x1 = (x1 - xMid) * zoom + halfWidth;
                    x2 = (x2 - xMid) * zoom + halfWidth;
                    y1 = (y1 - yMid) * zoom + halfHeight;
                    y2 = (y2 - yMid) * zoom + halfHeight;
                    gfx.DrawLine(usedPen, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            }

            // Draw actors
            foreach (var actor in map.Actors.Where(a => !(a is UnrealBrush)))
            {
                // Determine pen to use
                Pen usedPen;
                if (actor.Owner == importantMap)
                    usedPen = importantPen;
                else if (actor.Owner == draggedMap)
                    usedPen = draggedPen;
                else
                    usedPen = actorPen;

                // Draw dot
                Project(actor.Location, view, out double x, out double y);
                x = (x - xMid) * zoom + halfWidth;
                y = (y - yMid) * zoom + halfHeight;
                gfx.DrawRectangle(usedPen, (float)x, (float)y, 1f, 1f);
            }
        }

        /// <summary>
        /// Converts a 3D point into 2D coordinates appropriate for the selected view.
        /// No scaling or translation is performed yet.
        /// </summary>
        private static void Project(Point3D orig, View view, out double x, out double y)
        {
            switch (view)
            {
                case View.Top: x = orig.X; y = orig.Y; return;
                case View.Front: x = orig.X; y = -orig.Z; return;
                case View.Side: x = orig.Y; y = -orig.Z; return;
            }
            x = y = 0.0; // should never happen
        }
    }
}
