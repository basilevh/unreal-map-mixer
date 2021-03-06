﻿// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.MyMath
{
    /// <summary>
    /// Immutable class that represents a vector in a three-dimensional space.
    /// </summary>
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
        /// Copy constructor.
        /// Creates a copy of an existing vector, or creates a new vector from the origin to the given point.
        /// </summary>
        public Vector3D(Point3D point) : this(point.X, point.Y, point.Z)
        { }

        public Vector3D() : this(0.0, 0.0, 0.0)
        { }

        public new Vector3D Round(double step) => new Vector3D(base.Round(step));
    }
}
