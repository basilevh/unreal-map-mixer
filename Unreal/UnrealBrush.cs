// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
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
            polyFlags = brush.polyFlags;
            isInvisible = brush.isInvisible;
            isPortal = brush.isPortal;
            type = brush.type;
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
        /// Creates a read-only instance of a brush.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public new static UnrealBrush FromText(string text) => new UnrealBrush(text);

        private ulong polyFlags = 0;
        private bool isInvisible = false;
        private bool isPortal = false;
        private BrushType type = BrushType.Unknown;
        private string geometryText;
        private List<Polygon> polygons = new List<Polygon>();
        private List<Point3D> vertices = new List<Point3D>();
        private List<Line3D> edges = new List<Line3D>();

        public ulong PolyFlags => polyFlags;

        public bool IsInvisible => isInvisible;

        public bool IsPortal => isPortal;

        public BrushType Type => type;

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
            loadFlags(text);
            loadType(text);

            // Load geometry
            geometryText = T3DParser.GetGeometryText(text);
            polygons = T3DParser.LoadPolygons(geometryText, Location).ToList();

            // Process geometry
            loadVertices();
            loadEdges();
        }

        private void loadFlags(string text)
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
        }

        private void loadType(string text)
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

        #endregion

        #region Geometry

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
            geometryText = T3DParser.MoveVertex(geometryText, from, to, MinVertexDist);

            // Reload and process geometry
            polygons = T3DParser.LoadPolygons(geometryText, Location).ToList();
            loadVertices();
            loadEdges();
        }

        /// <returns>Whether this brush has at least one slanted surface.</returns>
        public bool IsSlanted() => polygons.Any(p => p.IsSlanted());

        /// <returns>Whether this brush is a non-slanted cuboid (i.e. a stretched cube).</returns>
        public bool IsCuboid()
        {
            return (!IsSlanted()
                && vertices.Count == 8 && polygons.Count == 6
                && polygons.All(p => p.Vertices.Count() == 4));
        }

        public double GetXMin() => vertices.Min(v => v.X);

        public double GetXMax() => vertices.Max(v => v.X);

        public double GetYMin() => vertices.Min(v => v.Y);

        public double GetYMax() => vertices.Max(v => v.Y);

        public double GetZMin() => vertices.Min(v => v.Z);

        public double GetZMax() => vertices.Max(v => v.Z);

        /// <returns>
        /// Whether this brush overlaps with or touches another brush,
        /// i.e. at least one point is common. If the result is unknown,
        /// null is returned.
        /// </returns>
        public bool? OverlapsWith(UnrealBrush other)
        {
            if (IsCuboid())
            {
                // TODO
                return null;
            }

            return null;
        }

        #endregion
    }
}
