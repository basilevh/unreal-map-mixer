// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    /// <summary>
    /// Immutable class that represents a point in a three-dimensional space.
    /// </summary>
    public class Point3D
    {
        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(Point3D point) : this(point.x, point.y, point.z)
        { }

        public Point3D() : this(0.0, 0.0, 0.0)
        { }

        public static Point3D FromProperty(string value)
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;

            var components = value.Substring(1, value.Length - 2).Split(',');
            foreach (string comp in components)
                if (comp.StartsWith("X="))
                {
                    if (!double.TryParse(comp.Substring(2), out x))
                        Console.WriteLine("Error while parsing location: " + value);
                }
                else if (comp.StartsWith("Y="))
                {
                    if (!double.TryParse(comp.Substring(2), out y))
                        Console.WriteLine("Error while parsing location: " + value);
                }
                else if (comp.StartsWith("Z="))
                {
                    if (!double.TryParse(comp.Substring(2), out z))
                        Console.WriteLine("Error while parsing location: " + value);
                }

            return new Point3D(x, y, z);
        }

        protected double x;
        protected double y;
        protected double z;

        public double X => x;

        public double Y => y;

        public double Z => z;

        public double DistSquaredTo(double x, double y, double z)
        {
            return (this.x - x) * (this.x - x)
                 + (this.y - y) * (this.y - y)
                 + (this.z - z) * (this.z - z);
        }

        public double DistanceTo(double x, double y, double z)
        {
            return Math.Sqrt(DistSquaredTo(x, y, z));
        }

        public double DistSquaredTo(Point3D other)
        {
            return DistSquaredTo(other.x, other.y, other.z);
        }

        public double DistanceTo(Point3D other)
        {
            return DistanceTo(other.x, other.y, other.z);
        }
    }
}
