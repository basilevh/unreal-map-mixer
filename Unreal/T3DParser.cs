// 30-06-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.Unreal
{
    public static class T3DParser
    {
        /* T3D Map Format:
         * Begin Map
         * Begin Actor Class=... Name=...
         *     Property=Value
         *     ...
         * End Actor
         * ...
         * End Map
         */

        public static IEnumerable<UnrealActor> LoadActors(string text)
        {
            int start = text.IndexOf("Begin Actor "); ;
            while (start != -1)
            {
                // Get length of this block
                int end = text.IndexOf("End Actor", start) + "End Actor".Length;
                int length = end - start;

                // Extract and yield actor
                string actorText = text.Substring(start, length);
                var actor = UnrealActorFactory.FromText(actorText);
                yield return actor; // increments actorCount and brushCount as necessary

                // Next iteration
                start = text.IndexOf("Begin Actor ", end);
            }
        }

        public static string GenerateText(UnrealMap map)
        {
            var builder = new StringBuilder();

            // Add header
            builder.AppendLine("Begin Map");
            // Add all actors
            foreach (var actor in map.Actors)
                builder.AppendLine(actor.Text);
            // Add footer
            builder.AppendLine("End Map");

            return builder.ToString();
        }

        public static string GenerateText(UnrealActor actor)
        {
            var builder = new StringBuilder();

            // Add header
            builder.AppendLine("Begin Actor Class=" + actor.Class + " Name=" + actor.Name);
            // Add all actors
            foreach (var property in actor.Properties)
                builder.AppendLine("\t" + property.Key + "=" + property.Value);
            // Add footer
            builder.AppendLine("End Actor");

            return builder.ToString();
        }

        public static string GenerateText(UnrealBrush brush)
        {
            var builder = new StringBuilder();

            // TODO

            return builder.ToString();
        }

        /// <summary>
        /// Gets a property by the specified key.
        /// </summary>
        /// <returns>The value if found, or null otherwise.</returns>
        public static string GetProperty(string text, string key)
        {
            var reader = new StringReader(text);
            string result;

            while (true)
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    // Check this line
                    line = line.TrimStart();
                    if (line.StartsWith(key + "="))
                    {
                        // Property found
                        result = line.Substring(key.Length + 1);
                        break;
                    }
                }
                else
                {
                    // End of text reached
                    result = null;
                    break;
                }
            }

            return result;
        }

        /* Polygon format:
         * ...
         * [?] PolyFlags=...
         * [?] Location=(X=...,Y=...,Z=...)
         * [?] Rotation=([?]Pitch=...,[?]Yaw=...,[?]Roll=...)
         * ...
         * Begin Brush Name=...
         *    Begin PolyList
         *       Begin Polygon ...
         *          ...
         *          Normal   x,y,z
         *          ...
         *          Vertex   x,y,z
         *          Vertex   x,y,z
         *          ...
         *       End Polygon
         *       ...
         *    End PolyList
         * End Brush
         */

        // TODO account for MainScale, Rotation, PostScale

        public static IEnumerable<Polygon> LoadPolygons(string text, Point3D origin)
        {
            List<Point3D> polyVerts = null;
            Vector3D polyNormal = null;

            var reader = new StringReader(text);
            string line = reader.ReadLine();
            while (line != null)
            {
                line = line.TrimStart();

                if (line.StartsWith("Begin Polygon"))
                {
                    // Start parsing a new polygon
                    polyVerts = new List<Point3D>();
                }

                else if (line.StartsWith("Normal "))
                {
                    // Assign this normal vector to the current polygon
                    string[] coords = line.Substring("Normal ".Length).Trim().Split(',');
                    if (double.TryParse(coords[0], out double x)
                        && double.TryParse(coords[1], out double y)
                        && double.TryParse(coords[2], out double z))
                        polyNormal = new Vector3D(x, y, z, true);
                    else
                        Console.WriteLine("Error at line: " + line);
                }

                else if (line.StartsWith("Vertex ") && polyVerts != null)
                {
                    string[] coords = line.Substring("Vertex ".Length).Trim().Split(',');
                    if (double.TryParse(coords[0], out double x)
                        && double.TryParse(coords[1], out double y)
                        && double.TryParse(coords[2], out double z)
                        && polyVerts != null)
                    {
                        // Get the true world coordinates by adding the location offset
                        x += origin.X;
                        y += origin.Y;
                        z += origin.Z;

                        // Add this vertex to the current polygon
                        var curVert = new Point3D(x, y, z);
                        polyVerts.Add(curVert);
                    }
                    else
                        Console.WriteLine("Error at line: " + line);
                }

                else if (line.StartsWith("End Polygon"))
                {
                    // Finished parsing this polygon, so yield it
                    if (polyVerts != null && polyNormal != null)
                    {
                        yield return new Polygon(polyVerts, polyNormal);

                        polyVerts = null;
                        polyNormal = null;
                    }
                    else
                        Console.WriteLine("Error while parsing polygon");
                }

                line = reader.ReadLine();
            }
        }
    }
}
