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

        public Line3D(Line3D line) : this(line.pt1, line.pt2)
        { }

        private Point3D pt1;
        private Point3D pt2;

        public Point3D Point1 => pt1;

        public Point3D Point2 => pt2;

        public bool ApproxEquals(Line3D other, double absTol)
        {
            // Use squared distances for performance
            double atolSq = absTol * absTol;
            return
                // Check for equal endpoints
                ((pt1.DistSquaredTo(other.pt1) < atolSq
                && pt2.DistSquaredTo(other.pt2) < atolSq))
                // Check for reversed endpoints
                || (pt1.DistSquaredTo(other.pt2) < atolSq
                && pt2.DistSquaredTo(other.pt1) < atolSq);
        }
    }
}
