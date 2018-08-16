// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Unreal
{
    public enum BrushOperation
    {
        Solid, SemiSolid, NonSolid, Subtract, Mover, Unknown
    }

    /// <summary>
    /// Special actor that represents a geometry Brush in Unreal Engine, including a Mover.
    /// </summary>
    public class UnrealBrush : UnrealActor
    {
        private const double MinVertexDist = 1e-3;
        private const double MinVertexDistSq = MinVertexDist * MinVertexDist;

        /// <summary>
        /// Creates a new modifiable brush.
        /// </summary>
        public UnrealBrush() : base()
        { }

        protected UnrealBrush(UnrealBrush brush) : base(brush)
        {
            Operation = brush.Operation;
            PolyFlags = brush.PolyFlags;
            IsInvisible = brush.IsInvisible;
            IsPortal = brush.IsPortal;
            MainScale = brush.MainScale;
            PostScale = brush.PostScale;
            polygons = brush.polygons.Select(p => new Polygon(p)).ToList();
            vertices = brush.vertices.Select(p => new Point3D(p)).ToList();
            edges = brush.edges.Select(l => new Line3D(l)).ToList();
        }

        protected UnrealBrush(string text) : base(text)
        { }

        /// <summary>
        /// Creates a modifiable deep copy of this brush.
        /// </summary>
        internal new UnrealBrush Duplicate() => new UnrealBrush(this);

        /// <summary>
        /// Creates a read-only instance of a brush.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public new static UnrealBrush FromText(string text) => new UnrealBrush(text);
        
        private List<Polygon> polygons = new List<Polygon>();
        private List<Point3D> vertices = new List<Point3D>();
        private List<Line3D> edges = new List<Line3D>();

        public BrushOperation Operation { get; private set; } = BrushOperation.Unknown;

        public ulong PolyFlags { get; private set; } = 0;

        public bool IsInvisible { get; private set; } = false;

        public bool IsPortal { get; private set; } = false;

        public Scale3D MainScale { get; private set; } = new Scale3D();

        public Scale3D PostScale { get; private set; } = new Scale3D();

        public bool IsScaled => (MainScale.X != 1.0 || MainScale.Y != 1.0 || MainScale.Z != 1.0 || MainScale.SheerRate != 0.0
            || PostScale.X != 1.0 || PostScale.Y != 1.0 || PostScale.Z != 1.0 || PostScale.SheerRate != 0.0);

        public string GeometryText { get; private set; }

        public IEnumerable<Polygon> Polygons => polygons;

        public IEnumerable<Point3D> Vertices => vertices;

        public IEnumerable<Line3D> Edges => edges;

        #region Text handling

        protected override string GenerateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void LoadText(string text)
        {
            // Load properties
            base.LoadText(text);
            LoadFlags();
            LoadOperation();
            LoadScale();

            // Load geometry
            GeometryText = T3DParser.GetGeometryText(text);
            ProcessGeometry();
        }

        private void LoadFlags()
        {
            PolyFlags = 0;
            IsInvisible = false;
            IsPortal = false;

            string value = GetProperty("PolyFlags");
            if (value != null && ulong.TryParse(value, out ulong polyFlags))
            {
                PolyFlags = polyFlags;
                IsInvisible = ((PolyFlags & 1 << 1) != 0);
                IsPortal = ((PolyFlags & 1 << 26) != 0);
            }

            // TODO: include individual polygons as well (round average?)
        }

        private void LoadOperation()
        {
            // https://wiki.beyondunreal.com/Legacy:PolyFlags
            Operation = BrushOperation.Unknown;

            if (Class == "Mover")
                Operation = BrushOperation.Mover;
            else
            {
                string value = GetProperty("CsgOper");
                if (value != null)
                {
                    if (value == "CSG_Add")
                    {
                        if ((PolyFlags & 1 << 5) != 0)
                            Operation = BrushOperation.SemiSolid;
                        else if ((PolyFlags & 1 << 3) != 0)
                            Operation = BrushOperation.NonSolid;
                        else
                            Operation = BrushOperation.Solid;
                    }
                    else if (value == "CSG_Subtract")
                        Operation = BrushOperation.Subtract;
                }
            }
        }

        private void LoadScale()
        {
            string value = GetProperty("MainScale");
            if (value != null)
                MainScale = Scale3D.FromProperty(value);
            value = GetProperty("PostScale");
            if (value != null)
                PostScale = Scale3D.FromProperty(value);
        }

        #endregion

        #region Geometry

        private void ProcessGeometry()
        {
            // TODO: apply rotation and scaling
            polygons = T3DParser.LoadPolygons(GeometryText, Location).ToList();
            loadVertices();
            loadEdges();
        }

        private void loadVertices()
        {
            vertices = new List<Point3D>();
            foreach (var poly in polygons)
            {
                foreach (var vertex in poly.Vertices)
                {
                    // Add this vertex to the total list of vertices, if not already present
                    if (!vertices.Any(v => v.ApproxEquals(vertex, MinVertexDist)))
                        vertices.Add(new Point3D(vertex));
                }
            }
        }

        private void loadEdges()
        {
            edges = new List<Line3D>();
            foreach (var poly in polygons)
            {
                foreach (var edge in poly.Edges)
                {
                    // Add this edge to the total list of edges, if not already present
                    if (!edges.Any(e => e.ApproxEquals(edge, MinVertexDist)))
                        edges.Add(new Line3D(edge));
                }
            }
        }

        public void MoveVertex(Point3D from, Point3D to)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");

            GeometryText = T3DParser.TranslateVertex(GeometryText, from, to, MinVertexDist);
            ProcessGeometry();
        }

        /// <returns>Whether this brush has at least one slanted surface.</returns>
        public bool IsSlanted() => polygons.Any(p => p.IsSlanted());

        /// <returns>Whether this brush is a non-slanted cuboid, i.e. a (possibly stretched) cube.</returns>
        public bool IsCuboid()
        {
            return (!IsSlanted()
                && vertices.Count == 8 && polygons.Count == 6
                && polygons.All(p => p.Vertices.Count() == 4));
        }

        /// <returns>The minimum X value of all vertices.</returns>
        public double GetXMin() => vertices.Min(v => v.X);

        /// <returns>The maximum X value of all vertices.</returns>
        public double GetXMax() => vertices.Max(v => v.X);

        /// <returns>The minimum Y value of all vertices.</returns>
        public double GetYMin() => vertices.Min(v => v.Y);

        /// <returns>The maximum Y value of all vertices.</returns>
        public double GetYMax() => vertices.Max(v => v.Y);

        /// <returns>The minimum Z value of all vertices.</returns>
        public double GetZMin() => vertices.Min(v => v.Z);

        /// <returns>The maximum Z value of all vertices.</returns>
        public double GetZMax() => vertices.Max(v => v.Z);

        /// <summary>
        /// Considers an encompassing cuboid bounded by the extremal vertex positions in each dimension to calculate a rough estimate of the volume.
        /// The actual volume is less than or equal to this number.
        /// </summary>
        /// <returns>An upper bound on the brush's volume.</returns>
        public double GetVolumeUpperBound() =>
            (GetXMax() - GetXMin()) * (GetYMax() - GetYMin()) * (GetZMax() - GetZMin());

        /// <returns>
        /// Whether this brush overlaps with or touches another brush,
        /// i.e. at least one point is common. If the result is unknown,
        /// null is returned.
        /// </returns>
        public bool? OverlapsWith(UnrealBrush other)
        {
            bool overlapX = (GetXMin() - other.GetXMax()) * (GetXMax() - other.GetXMin()) <= 0.0;
            bool overlapY = (GetYMin() - other.GetYMax()) * (GetYMax() - other.GetYMin()) <= 0.0;
            bool overlapZ = (GetZMin() - other.GetZMax()) * (GetZMax() - other.GetZMin()) <= 0.0;
            bool possible = (overlapX && overlapY && overlapZ);

            if (IsCuboid())
                return possible;

            if (possible)
                // The vertex bounds don't tell the whole story here
                // TODO: devise an algorithm
                return null;
            else
                return false;
        }
        
        /// <param name="point">The point to investigate.</param>
        /// <param name="minDist">The required minimum distance from any edge.</param>
        /// <returns>Whether the specified point is inside this brush.</returns>
        public bool? Encompasses(Point3D point, double minDist = 0.0)
        {
            bool inX = (GetXMin() + minDist <= point.X && point.X <= GetXMax() - minDist);
            bool inY = (GetYMin() + minDist <= point.Y && point.Y <= GetYMax() - minDist);
            bool inZ = (GetZMin() + minDist <= point.Z && point.Z <= GetZMax() - minDist);
            bool possible = (inX && inY && inZ);

            if (IsCuboid())
                return possible;

            if (possible)
                // The vertex bounds don't tell the whole story here
                // TODO: devise an algorithm
                return null;
            else
                return false;
        }

        /// <param name="actor">The actor to investigate.</param>
        /// <param name="minDist">The required minimum distance from any edge.</param>
        /// <returns>Whether the given actor is inside this brush.</returns>
        public bool? Encompasses(UnrealActor actor, double minDist = 0.0) => Encompasses(actor.Location, minDist);

        #endregion
    }
}
