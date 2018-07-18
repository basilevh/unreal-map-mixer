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
    public enum BrushType
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
            type = brush.type;
            polyFlags = brush.polyFlags;
            isInvisible = brush.isInvisible;
            isPortal = brush.isPortal;
            mainScale = brush.mainScale;
            postScale = brush.postScale;
            polygons = brush.polygons.Select(p => new Polygon(p)).ToList();
            vertices = brush.vertices.Select(p => new Point3D(p)).ToList();
            edges = brush.edges.Select(l => new Line3D(l)).ToList();
        }

        protected UnrealBrush(string text) : base(text)
        { }

        /// <summary>
        /// Creates a modifiable deep copy of this brush.
        /// </summary>
        public new UnrealBrush Duplicate() => new UnrealBrush(this);

        /// <summary>
        /// Creates a copy of this actor, translated by the given offset.
        /// </summary>
        public new UnrealBrush Duplicate(Vector3D translateOffset)
        {
            var result = new UnrealBrush(this);
            result.Translate(translateOffset);
            return result;
        }

        /// <summary>
        /// Creates a read-only instance of a brush.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public new static UnrealBrush FromText(string text) => new UnrealBrush(text);

        private BrushType type = BrushType.Unknown;
        private ulong polyFlags = 0;
        private bool isInvisible = false;
        private bool isPortal = false;
        private Scale3D mainScale = new Scale3D();
        private Scale3D postScale = new Scale3D();
        private string geometryText;
        private List<Polygon> polygons = new List<Polygon>();
        private List<Point3D> vertices = new List<Point3D>();
        private List<Line3D> edges = new List<Line3D>();

        public BrushType Type => type;

        public ulong PolyFlags => polyFlags;

        public bool IsInvisible => isInvisible;

        public bool IsPortal => isPortal;

        public Scale3D MainScale => mainScale;

        public Scale3D PostScale => postScale;

        public bool IsScaled => (mainScale.X != 1.0 || mainScale.Y != 1.0 || mainScale.Z != 1.0 || mainScale.SheerRate != 0.0
            || postScale.X != 1.0 || postScale.Y != 1.0 || postScale.Z != 1.0 || postScale.SheerRate != 0.0);

        public string GeometryText => geometryText;

        public IEnumerable<Polygon> Polygons => polygons;

        public IEnumerable<Point3D> Vertices => vertices;

        public IEnumerable<Line3D> Edges => edges;

        #region Text handling

        protected override string generateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void loadText(string text)
        {
            // Load properties
            base.loadText(text);
            loadFlags();
            loadType();
            loadScale();

            // Load geometry
            geometryText = T3DParser.GetGeometryText(text);
            processGeometry();
        }

        private void loadFlags()
        {
            polyFlags = 0;
            isInvisible = false;
            isPortal = false;

            string value = GetProperty("PolyFlags");
            if (value != null && ulong.TryParse(value, out polyFlags))
            {
                isInvisible = ((polyFlags & 1 << 1) != 0);
                isPortal = ((polyFlags & 1 << 26) != 0);
            }

            // TODO: include individual polygons as well (round average?)
        }

        private void loadType()
        {
            // https://wiki.beyondunreal.com/Legacy:PolyFlags
            type = BrushType.Unknown;

            if (Class == "Mover")
                type = BrushType.Mover;
            else
            {
                string value = GetProperty("CsgOper");
                if (value != null)
                {
                    if (value == "CSG_Add")
                    {
                        if ((polyFlags & 1 << 5) != 0)
                            type = BrushType.SemiSolid;
                        else if ((polyFlags & 1 << 3) != 0)
                            type = BrushType.NonSolid;
                        else
                            type = BrushType.Solid;
                    }
                    else if (value == "CSG_Subtract")
                        type = BrushType.Subtract;
                }
            }
        }

        private void loadScale()
        {
            string value = GetProperty("MainScale");
            if (value != null)
                mainScale = Scale3D.FromProperty(value);
            value = GetProperty("PostScale");
            if (value != null)
                postScale = Scale3D.FromProperty(value);
        }

        #endregion

        #region Geometry

        private void processGeometry()
        {
            // TODO: apply rotation and scaling
            polygons = T3DParser.LoadPolygons(geometryText, Location).ToList();
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

            geometryText = T3DParser.TranslateVertex(geometryText, from, to, MinVertexDist);
            processGeometry();
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
