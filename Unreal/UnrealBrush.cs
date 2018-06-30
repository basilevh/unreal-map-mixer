// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

        #region Constructors

        /// <summary>
        /// Creates a read-only instance of a brush.
        /// </summary>
        /// <param name="text">Text representation of the brush</param>
        public UnrealBrush(string text) : base(text)
        {
            loadText(text);
            getVertices();
            getEdges();
        }

        #endregion

        protected ulong polyFlags;
        protected bool isInvisible;
        protected bool isPortal;
        protected BrushType type;
        protected List<Polygon> polygons;
        protected List<Point3D> vertices;
        protected List<Line3D> edges;

        #region Public fields

        public ulong PolyFlags => polyFlags;

        public bool IsInvisible => isInvisible;

        public bool IsPortal => isPortal;

        public BrushType Type => type;

        public IEnumerable<Polygon> Polygons => polygons;

        public IEnumerable<Point3D> Vertices => vertices;

        public IEnumerable<Line3D> Edges => edges;

        #endregion

        #region Text handling

        private void loadText(string text)
        {
            loadFlags(text);
            loadType(text);
            loadPolys(text);
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

            if (actorClass == "Mover")
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

        /* Polygon format:
         * ...
         * [?] PolyFlags=...
         * [?] Location=(X=...,Y=...,Z=...)
         * [?] Rotation=([?]Pitch=...,[?]Yaw=...,[?]Roll=...)
         * ...
         * Begin Brush Name=...
         *    Begin PolyList
         *       Begin Polygon ...
         *          ...
         *          Normal   x,y,z
         *          ...
         *          Vertex   x,y,z
         *          Vertex   x,y,z
         *          ...
         *       End Polygon
         *       ...
         *    End PolyList
         * End Brush
         */

        // TODO account for MainScale, Rotation, PostScale

        private void loadPolys(string text)
        {
            polygons = new List<Polygon>();
            List<Point3D> polyVerts = null;
            Vector3D polyNormal = null;

            var reader = new StringReader(text);
            string line = reader.ReadLine();
            while (line != null)
            {
                line = line.TrimStart();

                if (line.StartsWith("Begin Polygon"))
                {
                    polyVerts = new List<Point3D>();
                }
                else if (line.StartsWith("Normal "))
                {
                    string[] coords = line.Substring("Normal ".Length).Trim().Split(',');
                    double x, y, z;
                    if (double.TryParse(coords[0], out x)
                        && double.TryParse(coords[1], out y)
                        && double.TryParse(coords[2], out z))
                        polyNormal = new Vector3D(x, y, z, true);
                    else
                        Console.WriteLine("Error at line: " + line);
                }
                else if (line.StartsWith("Vertex ") && polyVerts != null)
                {
                    string[] coords = line.Substring("Vertex ".Length).Trim().Split(',');
                    double x, y, z;
                    if (double.TryParse(coords[0], out x)
                        && double.TryParse(coords[1], out y)
                        && double.TryParse(coords[2], out z)
                        && polyVerts != null)
                    {
                        // Get the true world coordinates by adding the location offset
                        x += location.X;
                        y += location.Y;
                        z += location.Z;
                        // Add this vertex to the current polygon
                        var curVert = new Point3D(x, y, z);
                        polyVerts.Add(curVert);
                    }
                    else
                        Console.WriteLine("Error at line: " + line);
                }
                else if (line.StartsWith("End Polygon"))
                {
                    // Finished parsing this polygon, so add it
                    if (polyVerts != null && polyNormal != null)
                    {
                        polygons.Add(new Polygon(polyVerts, polyNormal));
                        polyVerts = null;
                        polyNormal = null;
                    }
                    else
                        Console.WriteLine("Error while parsing polygon");
                }

                line = reader.ReadLine();
            }
        }

        #endregion

        #region Geometry

        private void getVertices()
        {
            vertices = new List<Point3D>();
            foreach (var poly in polygons)
            {
                foreach (var vertex in poly.Vertices)
                {
                    // Add this vertex to the total list of vertices, if not already present
                    if (vertices.All(v => v.DistSquaredTo(vertex) > MinVertexDistSq))
                        vertices.Add(vertex);
                }
            }
        }

        private void getEdges()
        {
            edges = new List<Line3D>();
            foreach (var poly in polygons)
            {
                foreach (var edge in poly.Edges)
                {
                    // Add this edge to the total list of edges, if not already present
                    if (!edges.Any(e => e.ApproxEquals(edge, MinVertexDist)))
                        edges.Add(edge);
                }
            }
        }

        /// <returns>Whether this brush has at least one slanted surface.</returns>
        public bool IsSlanted() => polygons.Any(p => p.IsSlanted());

        /// <returns>Whether this brush is a non-slanted cube.</returns>
        public bool IsCube()
        {
            return (!IsSlanted()
                && vertices.Count == 8 && polygons.Count == 6
                && polygons.All(p => p.Vertices.Count() == 4));
        }

        public double GetXMin() => vertices.Min(v => v.X);

        public double GetXMax() => vertices.Max(v => v.X);

        public double GetYMin() => vertices.Min(v => v.X);

        public double GetYMax() => vertices.Max(v => v.X);

        public double GetZMin() => vertices.Min(v => v.X);

        public double GetZMax() => vertices.Max(v => v.X);

        /// <returns>
        /// Whether this brush overlaps with or touches another brush,
        /// i.e. at least one point is common. If the result is unknown,
        /// null is returned.
        /// </returns>
        public bool? Overlaps(UnrealBrush other)
        {
            if (IsCube())
            {
                // TODO
                return null;
            }

            return null;
        }

        #endregion
    }
}
