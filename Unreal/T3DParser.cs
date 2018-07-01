// 30-06-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.Unreal
{
    /// <summary>
    /// Utility class for all direct I/O with T3D text representations.
    /// </summary>
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

        /// <summary>
        /// Collects all actors from a T3D representation.
        /// </summary>
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

        /// <summary>
        /// Collects all properties from an actor's T3D representation.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, string>> GetProperties(string text)
        {
            var reader = new StringReader(text);
            bool inBrush = false;
            string line = reader.ReadLine();
            while (line != null)
            {
                line = line.TrimStart();

                if (!inBrush && !line.StartsWith("Begin Actor") && !line.StartsWith("End Actor"))
                {
                    if (line.StartsWith("Begin Brush"))
                        // This is a special brush-specific region with no relevant properties inside
                        inBrush = true;
                    else
                    {
                        // Find the equals sign and yield the property
                        int separator = line.IndexOf('=');
                        if (separator != -1)
                        {
                            string key = line.Substring(0, separator);
                            string value = line.Substring(separator + 1);
                            yield return new KeyValuePair<string, string>(key, value);
                        }
                    }
                }
                else if (inBrush && line.StartsWith("End Brush"))
                    // End of brush-specific region
                    inBrush = false;

                line = reader.ReadLine();
            }
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

        /// <summary>
        /// Extracts the geometry part from a T3D representation of a brush.
        /// </summary>
        public static string GetGeometryText(string text)
        {
            int start = text.IndexOf("Begin Brush");
            int end = text.IndexOf("End Brush") + "End Brush".Length;
            return text.Substring(start, end - start);
        }

        /* Polygon format (? means not always present):
         * ...
         * [?]PolyFlags=...
         * [?]Location=(X=...,Y=...,Z=...)
         * [?]Rotation=([?]Pitch=...,[?]Yaw=...,[?]Roll=...)
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

        /// <summary>
        /// Collects all polygons from a brush's T3D representation
        /// </summary>
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

        /// <summary>
        /// Generates a complete T3D file starting from a map instance.
        /// </summary>
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

        /// <summary>
        /// Generates the T3D representation of an actor instance.
        /// </summary>
        public static string GenerateText(UnrealActor actor)
        {
            var builder = new StringBuilder();

            // Add header
            builder.AppendLine("Begin Actor Class=" + actor.Class + " Name=" + actor.Name);
            // Add all properties
            builder.AppendLine(generateProperties(actor));
            // Add footer
            builder.AppendLine("End Actor");

            return builder.ToString();
        }

        /// <summary>
        /// Generates the T3D representation of a brush instance.
        /// </summary>
        public static string GenerateText(UnrealBrush brush)
        {
            var builder = new StringBuilder();

            // Add header
            builder.AppendLine("Begin Actor Class=Brush Name=" + brush.Name);
            // Add all properties
            builder.AppendLine(generateProperties(brush));
            // Add geometry part
            builder.AppendLine(brush.GeometryText);
            // Add footer
            builder.AppendLine("End Actor");

            return builder.ToString();
        }

        /// <summary>
        /// Generates an extensible T3D representation of an actor instance, so minus the header and footer.
        /// </summary>
        private static string generateProperties(UnrealActor actor)
        {
            var builder = new StringBuilder();

            // Add all properties
            foreach (var property in actor.Properties)
                builder.AppendLine("\t" + property.Key + "=" + property.Value);

            return builder.ToString();
        }

        /// <summary>
        /// Modifies a T3D geometry representation and changes all matching vertices to the desired location.
        /// </summary>
        public static string MoveVertex(string geometryText, Point3D from, Point3D to, double absTol)
        {
            string newCoords = T3DFormatter.GetVertex(to);
            var reader = new StringReader(geometryText);
            var builder = new StringBuilder();
            string line = reader.ReadLine();

            while (line != null)
            {
                var curVert = parseVertex(line);
                if (curVert != null && curVert.ApproxEquals(from, absTol))
                    // Replace this line with the new vertex
                    line = "             Vertex   " + newCoords;

                builder.AppendLine(line);
                line = reader.ReadLine();
            }

            return builder.ToString();
        }

        private static Point3D parseVertex(string line)
        {
            int vertexIndex = line.IndexOf("Vertex ");
            if (vertexIndex != -1)
            {
                string[] coords = line.Substring(vertexIndex + "Vertex ".Length).Trim().Split(',');
                if (double.TryParse(coords[0], out double x)
                            && double.TryParse(coords[1], out double y)
                            && double.TryParse(coords[2], out double z))
                {
                    return new Point3D(x, y, z);
                }
            }
            return null;
        }
    }
}