using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.MyMath
{
    public enum SheerAxis
    {
        XY, XZ, YX, YZ, ZX, ZY
    }

    /// <summary>
    /// Immutable class that represents scaling and sheering information in a three-dimensional space.
    /// </summary>
    public class Scale3D : Vector3D
    {
        public Scale3D(double x, double y, double z) : base(x, y, z)
        { }

        public Scale3D(double x, double y, double z, SheerAxis sheerAxis, double sheerRate) : this(x, y, z)
        {
            this.sheerAxis = sheerAxis;
            this.sheerRate = sheerRate;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Scale3D(Point3D point) : this(point.X, point.Y, point.Z)
        { }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Scale3D(Scale3D scale) : this(scale.X, scale.Y, scale.Z, scale.sheerAxis, scale.sheerRate)
        { }

        public Scale3D() : this(1.0, 1.0, 1.0)
        { }

        public new static Scale3D FromProperty(string value)
        {
            // Get numbers
            double x = 1.0;
            double y = 1.0;
            double z = 1.0;
            int start = value.IndexOf("(Scale=(");
            if (start != -1)
            {
                start += +"(Scale=(".Length;
                int end = value.IndexOf(")", start);
                var components = value.Substring(start, end - start).Split(',');
                foreach (string comp in components)
                    if (comp.StartsWith("X="))
                    {
                        if (!double.TryParse(comp.Substring(2), out x))
                            Console.WriteLine("Error while parsing scale: Unknown X: " + value);
                    }
                    else if (comp.StartsWith("Y="))
                    {
                        if (!double.TryParse(comp.Substring(2), out y))
                            Console.WriteLine("Error while parsing scale: Unknown Y: " + value);
                    }
                    else if (comp.StartsWith("Z="))
                    {
                        if (!double.TryParse(comp.Substring(2), out z))
                            Console.WriteLine("Error while parsing scale: Unknown Z: " + value);
                    }
            }

            // Get sheer axis
            SheerAxis axis = SheerAxis.ZX;
            start = value.IndexOf("SheerAxis=");
            if (start != -1)
            {
                start += "SheerAxis=".Length;
                string axisText = value.Substring(start + "SHEER_".Length, 2);
                switch (axisText)
                {
                    case "XY":
                        axis = SheerAxis.XY;
                        break;
                    case "XZ":
                        axis = SheerAxis.XZ;
                        break;
                    case "YX":
                        axis = SheerAxis.YX;
                        break;
                    case "YZ":
                        axis = SheerAxis.YZ;
                        break;
                    case "ZX":
                        axis = SheerAxis.ZX;
                        break;
                    case "ZY":
                        axis = SheerAxis.ZY;
                        break;
                    default:
                        Console.WriteLine("Error while parsing scale: Unknown axis: " + value);
                        break;
                }
            }

            // Get sheer rate
            double rate = 0.0;
            start = value.IndexOf("SheerRate=");
            if (start != -1)
            {
                start += "SheerAxis=".Length;
                int end = value.IndexOf(")", start);
                if (!double.TryParse(value.Substring(start, end - start), out rate))
                    Console.WriteLine("Error while parsing scale: Unknown rate: " + value);
            }

            return new Scale3D(x, y, z, axis, rate);
        }

        private SheerAxis sheerAxis = SheerAxis.ZX;
        private double sheerRate = 0.0;

        public SheerAxis SheerAxis => sheerAxis;

        public double SheerRate => sheerRate;
    }
}
