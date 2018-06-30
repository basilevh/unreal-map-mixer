// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    /// <summary>
    /// Read-only class that represents an Actor in Unreal Engine.
    /// </summary>
    public class UnrealActor
    {
        #region Constructors

        /// <summary>
        /// Creates a read-only instance of an actor.
        /// </summary>
        /// <param name="text">Text representation of the actor</param>
        public UnrealActor(string text)
        {
            this.text = text;

            string firstLine = new StringReader(text).ReadLine();
            int classStart = firstLine.IndexOf("Class=", "Begin Actor ".Length);
            int classEnd = classStart + "Class=".Length;
            int nameStart = firstLine.IndexOf("Name=", classEnd);
            int nameEnd = nameStart + "Name=".Length;
            int classLength = nameStart - 1 - classEnd;
            int nameLength = firstLine.Length - nameEnd;

            actorClass = text.Substring(classEnd, classLength);
            actorName = text.Substring(nameEnd, nameLength);
            loadPosition(text);
        }

        #endregion

        protected string text;
        protected string actorClass;
        protected string actorName;
        protected Point3D location;
        protected Rotation3D rotation;

        #region Public fields

        public string Text => text;

        public string Class => actorClass;

        public string Name => actorName;

        public Point3D Location => location;

        public Rotation3D Rotation => rotation;

        #endregion

        #region Text handling

        /// <summary>
        /// Gets a property by the specified key.
        /// </summary>
        /// <returns>The value if found, null otherwise.</returns>
        public string GetProperty(string key)
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

        private void loadPosition(string text)
        {
            string loc = GetProperty("Location");
            string rot = GetProperty("Rotation");

            // Assign location
            if (loc != null)
                location = Point3D.FromProperty(loc);
            else
                // No location supplied, so it's default = all zero
                location = new Point3D(0.0, 0.0, 0.0);

            // Assign rotation
            if (rot != null)
                rotation = Rotation3D.FromProperty(rot);
            else
                // No rotation supplied, so it's default = all zero
                rotation = new Rotation3D(0.0, 0.0, 0.0);
        }

        #endregion
    }
}
