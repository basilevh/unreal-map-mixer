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
    }
}
