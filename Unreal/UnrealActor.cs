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
            Class = actor.Class;
            Name = actor.Name;
            Location = actor.Location;
            Rotation = actor.Rotation;
            // This duplicated actor has no owner (yet)
        }

        protected UnrealActor(string text) : base(text)
        { }

        /// <summary>
        /// Creates a modifiable deep copy of this actor.
        /// </summary>
        internal UnrealActor Duplicate() => new UnrealActor(this);

        /// <summary>
        /// Creates a read-only instance of an actor.
        /// </summary>
        /// <param name="text">T3D representation to be parsed</param>
        public static UnrealActor FromText(string text) => new UnrealActor(text);

        private Dictionary<string, string> properties = new Dictionary<string, string>();

        public string Class { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<KeyValuePair<string, string>> Properties => properties;

        public string GetProperty(string key) => (properties.ContainsKey(key) ? properties[key] : null);

        public void SetProperty(string key, string value)
        {
            properties[key] = value;
        }

        public Point3D Location { get; private set; } = new Point3D();

        public Rotation3D Rotation { get; private set; } = new Rotation3D();

        public bool IsRotated => (Rotation.Pitch != 0.0 || Rotation.Yaw != 0.0 || Rotation.Roll != 0.0);

        public UnrealMap Owner { get; internal set; } = null; // taken care of by UnrealMap

        #region Text handling

        protected override string GenerateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void LoadText(string text)
        {
            string firstLine = new StringReader(text).ReadLine();
            int classStart = firstLine.IndexOf("Class=", "Begin Actor ".Length);
            int classEnd = classStart + "Class=".Length;
            int nameStart = firstLine.IndexOf("Name=", classEnd);
            int nameEnd = nameStart + "Name=".Length;
            int classLength = nameStart - 1 - classEnd;
            int nameLength = firstLine.Length - nameEnd;

            Class = text.Substring(classEnd, classLength);
            Name = text.Substring(nameEnd, nameLength);
            properties = T3DParser.GetProperties(text).ToDictionary(p => p.Key, p => p.Value);
            LoadPosition();
        }

        private void LoadPosition()
        {
            properties.TryGetValue("Location", out string loc);
            properties.TryGetValue("Rotation", out string rot);

            // Assign location
            if (loc != null)
                Location = Point3D.FromProperty(loc);
            else
                // No location supplied, so return the default = all zero
                Location = new Point3D(0.0, 0.0, 0.0);

            // Assign rotation
            if (rot != null)
                Rotation = Rotation3D.FromProperty(rot);
            else
                // No rotation supplied, so return the default = all zero
                Rotation = new Rotation3D(0.0, 0.0, 0.0);
        }

        #endregion

        public void Translate(Vector3D offset)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");

            Location = Location.Add(offset);
        }
    }
}
