// 19-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.MyMath
{
    /// <summary>
    /// Immutable class that represents an Euler-angle orientation in a three-dimensional space.
    /// </summary>
    public class Rotation3D
    {
        public Rotation3D(double pitch, double yaw, double roll)
        {
            this.pitch = pitch;
            this.yaw = yaw;
            this.roll = roll;
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        public Rotation3D(Rotation3D rotation) : this(rotation.pitch, rotation.yaw, rotation.roll)
        { }

        public Rotation3D() : this(0.0, 0.0, 0.0)
        { }

        public static Rotation3D FromProperty(string value)
        {
            double pitch = 0.0;
            double yaw = 0.0;
            double roll = 0.0;

            var components = value.Substring(1, value.Length - 2).Split(',');
            foreach (string comp in components)
                if (comp.StartsWith("Pitch="))
                {
                    if (!double.TryParse(comp.Substring("Pitch=".Length), out pitch))
                        Console.WriteLine("Error while parsing rotation: " + value);
                }
                else if (comp.StartsWith("Yaw="))
                {
                    if (!double.TryParse(comp.Substring("Yaw=".Length), out yaw))
                        Console.WriteLine("Error while parsing rotation: " + value);
                }
                else if (comp.StartsWith("Roll="))
                {
                    if (!double.TryParse(comp.Substring("Roll=".Length), out roll))
                        Console.WriteLine("Error while parsing rotation: " + value);
                }

            return new Rotation3D(pitch, yaw, roll);
        }

        protected double pitch;
        protected double yaw;
        protected double roll;

        public double Pitch => pitch;

        public double Yaw => yaw;

        public double Roll => roll;
    }
}
