// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public class Line3D
    {
        public Line3D(Point3D pt1, Point3D pt2)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Line3D(Line3D line)
        {
            pt1 = new Point3D(line.pt1);
            pt2 = new Point3D(line.pt2);
        }

        private Point3D pt1;
        private Point3D pt2;

        public Point3D Point1 => pt1;

        public Point3D Point2 => pt2;

        public bool ApproxEquals(Line3D other, double absTol)
        {
            return
                // Check for equal endpoints
                (pt1.ApproxEquals(other.pt1, absTol)
                && pt2.ApproxEquals(other.pt2, absTol))
                // Check for reversed endpoints
                || (pt1.ApproxEquals(other.pt2, absTol)
                && pt2.ApproxEquals(other.pt1, absTol));
        }
    }
}
