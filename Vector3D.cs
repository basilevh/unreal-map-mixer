// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public class Vector3D : Point3D
    {
        public Vector3D(double x, double y, double z, bool normalize)
        {
            double div = 1.0;
            if (normalize)
                div = Math.Sqrt(x * x + y * y + z * z);
            this.x = x / div;
            this.y = y / div;
            this.z = z / div;
        }

        public Vector3D(double x, double y, double z) : this(x, y, z, false)
        { }

        /// <summary>
        /// Creates a copy of an existing vector, or creates a vector from the origin to the given point.
        /// </summary>
        public Vector3D(Point3D point) : this(point.X, point.Y, point.Z)
        { }
    }
}
