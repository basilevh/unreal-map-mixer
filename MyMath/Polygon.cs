// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;

namespace UnrealMapMixer
{
    public class Polygon
    {
        public Polygon(List<Point3D> vertices, Vector3D normal)
        {
            this.vertices = new List<Point3D>(vertices);
            this.normal = new Vector3D(normal);

            // Get all edges
            // In T3D, consecutive vertex pairs (including last-first) determine the edges
            var verts1 = vertices; // original list
            var verts2 = vertices.Skip(1).Concat(new[] { vertices.First() }); // cyclic shift
            edges = Enumerable.Zip(verts1, verts2,
                        (v, w) => new Line3D(v, w)).ToList();
        }
        
        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Polygon(Polygon polygon)
        {
            vertices = polygon.vertices.Select(p => new Point3D(p)).ToList();
            normal = new Vector3D(polygon.normal);
        }

        private List<Point3D> vertices;
        private Vector3D normal;
        private List<Line3D> edges;

        public IEnumerable<Point3D> Vertices => vertices;

        public Vector3D Normal => normal;

        public IEnumerable<Line3D> Edges => edges;

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
