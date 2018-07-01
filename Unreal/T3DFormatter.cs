// 01-07-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.Unreal
{
    /// <summary>
    /// Utility class for T3D number formatting.
    /// </summary>
    public static class T3DFormatter
    {
        private const string VertexFormat = "00000.000000";

        public static string GetVertexCoord(double coord)
        {
            return ((coord >= 0.0 ? "+" : "") + coord.ToString(VertexFormat));
        }

        public static string GetVertex(Point3D vertex)
        {
            return (GetVertexCoord(vertex.X) + ","
                + GetVertexCoord(vertex.Y) + ","
                + GetVertexCoord(vertex.Z));
        }
    }
}
