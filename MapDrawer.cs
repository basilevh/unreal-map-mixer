// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public class MapDrawer
    {
        public MapDrawer(UnrealMap map)
        {
            this.map = map;
        }

        private UnrealMap map;

        public void DrawLayout(Graphics gfx, int width, int height)
        {
            // Variables
            double halfWidth = width / 2.0;
            double halfHeight = height / 2.0;
            double xMin = map.Brushes.Min(b => b.GetXMin());
            double xMax = map.Brushes.Max(b => b.GetXMax());
            double yMin = map.Brushes.Min(b => b.GetYMin());
            double yMax = map.Brushes.Max(b => b.GetYMax());
            double xMid = (xMin + xMax) / 2.0; // at the center of the display
            double yMid = (yMin + yMax) / 2.0; // at the center of the display
            double xRan = xMax - xMin;
            double yRan = yMax - yMin;
            double zoom = Math.Min(width / xRan, height / yRan) * 0.99; // pixels per world unit, set to 'Fill' mode
            var solidPen = new Pen(new SolidBrush(Color.FromArgb(64, 64, 255)));
            var semiSolidPen = new Pen(new SolidBrush(Color.FromArgb(255, 128, 0)));
            var nonSolidPen = new Pen(new SolidBrush(Color.FromArgb(0, 255, 0)));
            var subtractPen = new Pen(new SolidBrush(Color.FromArgb(255, 255, 0)));
            var moverPen = new Pen(new SolidBrush(Color.FromArgb(255, 0, 255)));
            var unknownPen = new Pen(new SolidBrush(Color.FromArgb(128, 128, 128)));
            var actorPen = new Pen(new SolidBrush(Color.FromArgb(0, 255, 255)));
            gfx.Clear(Color.Black);

            // Draw brushes
            foreach (var brush in map.Brushes)
            {
                // Determine pen to use
                Pen usedPen;
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
                    double x1 = (edge.Point1.X - xMid) * zoom + halfWidth;
                    double x2 = (edge.Point2.X - xMid) * zoom + halfWidth;
                    double y1 = (edge.Point1.Y - yMid) * zoom + halfHeight;
                    double y2 = (edge.Point2.Y - yMid) * zoom + halfHeight;
                    gfx.DrawLine(usedPen, (float)x1, (float)y1, (float)x2, (float)y2);
                }
            }

            // Draw actors
            foreach (var actor in map.Actors.Where(a => !(a is UnrealBrush)))
            {
                double x = (actor.Location.X - xMid) * zoom + halfWidth;
                double y = (actor.Location.Y - yMid) * zoom + halfHeight;
                gfx.DrawRectangle(actorPen, (float)x, (float)y, 1f, 1f);
            }
        }
    }
}
