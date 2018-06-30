// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public class Polygon
    {
        public Polygon(List<Point3D> vertices, Vector3D normal)
        {
            this.vertices = new List<Point3D>(vertices);
            this.normal = new Vector3D(normal);
            getEdges();
        }

        private List<Point3D> vertices;
        private Vector3D normal; // mathematically wrong datatype but same purpose
        private List<Line3D> edges;

        public IEnumerable<Point3D> Vertices => vertices;

        public Vector3D Normal => normal;

        public IEnumerable<Line3D> Edges => edges;

        private void getEdges()
        {
            // Consecutive vertex pairs (including last-first) determine the edges
            var verts1 = vertices;
            var verts2 = vertices.Skip(1).Concat(new[] { vertices.First() }); // cyclic shift
            edges = Enumerable.Zip(verts1, verts2,
                        (v, w) => new Line3D(v, w)).ToList();
        }

        /// <returns>Whether the normal vector is non-zero in one dimension only.</returns>
        public bool IsSlanted() => (getNonZeroDims() == 1);

        private int getNonZeroDims()
        {
            int result = 0;
            if (normal.X != 0)
                result++;
            if (normal.Y != 0)
                result++;
            if (normal.Z != 0)
                result++;
            return result;
        }
    }
}
