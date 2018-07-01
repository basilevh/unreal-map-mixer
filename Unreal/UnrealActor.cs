// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Unreal
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
        { }

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
        /// Creates a copy of this actor, translated by the given offset.
        /// </summary>
        public UnrealActor Duplicate(Vector3D translateOffset)
        {
            var result = new UnrealActor(this);
            if (!translateOffset.IsZero())
                result.Translate(translateOffset);
            return result;
        }

        /// <summary>
        /// Creates a read-only instance of an actor.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public static UnrealActor FromText(string text) => new UnrealActor(text);

        private string actorClass;
        private string actorName;
        private Dictionary<string, string> properties = new Dictionary<string, string>();
        private Point3D location = new Point3D();
        private Rotation3D rotation = new Rotation3D();

        public string Class => actorClass;

        public string Name => actorName;

        public IEnumerable<KeyValuePair<string, string>> Properties => properties;

        public string GetProperty(string key) => (properties.ContainsKey(key) ? properties[key] : null);

        public void SetProperty(string key, string value)
        {
            properties[key] = value;
        }

        public Point3D Location => location;

        public Rotation3D Rotation => rotation;

        public bool IsRotated => (rotation.Pitch != 0.0 || rotation.Yaw != 0.0 || rotation.Roll != 0.0);

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
            properties = T3DParser.GetProperties(text).ToDictionary(p => p.Key, p => p.Value);
            loadPosition();
        }

        private void loadPosition()
        {
            properties.TryGetValue("Location", out string loc);
            properties.TryGetValue("Rotation", out string rot);

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

        public void Translate(Vector3D offset)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");

            location = location.Add(offset);
        }
    }
}
