// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    /// <summary>
    /// Represents an Actor in Unreal Engine.
    /// </summary>
    public class UnrealActor : UnrealObject
    {
        /// <summary>
        /// Creates a new modifiable actor.
        /// </summary>
        public UnrealActor() : base()
        {
            properties = new Dictionary<string, string>();
            actorClass = null;
            actorName = null;
            location = new Point3D();
            rotation = new Rotation3D();
        }

        protected UnrealActor(UnrealActor actor) : base(actor)
        {
            properties = new Dictionary<string, string>(actor.properties);
            actorClass = actor.actorClass;
            actorName = actor.actorName;
            location = actor.location;
            rotation = actor.rotation;
        }

        protected UnrealActor(string text) : base(text)
        { }

        /// <summary>
        /// Creates a modifiable deep copy of this actor.
        /// </summary>
        public UnrealActor Duplicate() => new UnrealActor(this);

        /// <summary>
        /// Creates a read-only instance of an actor.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public static UnrealActor FromText(string text) => new UnrealActor(text);

        protected Dictionary<string, string> properties;
        protected string actorClass;
        protected string actorName;
        protected Point3D location;
        protected Rotation3D rotation;

        public IEnumerable<KeyValuePair<string, string>> Properties => properties;

        public string GetProperty(string key) => properties[key];

        public void SetProperty(string key, string value)
        {
            properties[key] = value;
        }

        public string Class => actorClass;

        public string Name => actorName;

        public Point3D Location => location;

        public Rotation3D Rotation => rotation;

        #region Text handling

        protected override string generateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void loadText(string text)
        {
            string firstLine = new StringReader(text).ReadLine();
            int classStart = firstLine.IndexOf("Class=", "Begin Actor ".Length);
            int classEnd = classStart + "Class=".Length;
            int nameStart = firstLine.IndexOf("Name=", classEnd);
            int nameEnd = nameStart + "Name=".Length;
            int classLength = nameStart - 1 - classEnd;
            int nameLength = firstLine.Length - nameEnd;

            actorClass = text.Substring(classEnd, classLength);
            actorName = text.Substring(nameEnd, nameLength);
            loadProperties(text);
            loadPosition(text);
        }

        private void loadProperties(string text)
        {
            // TODO
        }

        private void loadPosition(string text)
        {
            string loc = properties["Location"];
            string rot = properties["Rotation"];

            // Assign location
            if (loc != null)
                location = Point3D.FromProperty(loc);
            else
                // No location supplied, so return the default = all zero
                location = new Point3D(0.0, 0.0, 0.0);

            // Assign rotation
            if (rot != null)
                rotation = Rotation3D.FromProperty(rot);
            else
                // No rotation supplied, so return the default = all zero
                rotation = new Rotation3D(0.0, 0.0, 0.0);
        }

        #endregion
    }
}
