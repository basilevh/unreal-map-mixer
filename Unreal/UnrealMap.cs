// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    /// <summary>
    /// Represents a game level in Unreal Engine.
    /// </summary>
    public class UnrealMap : UnrealObject
    {
        /// <summary>
        /// Creates a new modifiable map.
        /// </summary>
        public UnrealMap() : base()
        {
            title = "New UMM Map";
            author = null;
            song = null;
            actors = new List<UnrealActor>();
            brushes = new List<UnrealBrush>();
            actorCount = 0;
            brushCount = 0;
        }

        protected UnrealMap(UnrealMap map) : base(map)
        {
            title = map.title;
            author = map.author;
            song = map.song;
            actors.AddRange(map.Actors.Select(a => a.Duplicate()));
            brushes.AddRange(map.Brushes.Select(b => b.Duplicate()));
            actorCount = map.actorCount;
            brushCount = map.brushCount;
        }

        protected UnrealMap(string text) : base(text)
        { }

        /// <summary>
        /// Creates a modifiable deep copy of this map.
        /// </summary>
        public UnrealMap Duplicate() => new UnrealMap(this);

        /// <summary>
        /// Creates a read-only instance of a map.
        /// </summary>
        /// <param name="text">T3D file contents to be parsed</param>
        public static UnrealMap FromText(string text) => new UnrealMap(text);

        private string title;
        private string author;
        private string song;
        private List<UnrealActor> actors;
        private List<UnrealBrush> brushes;
        private int actorCount;
        private int brushCount;

        /// <summary>
        /// The file content for this map. This can be either the original text or newly generated text.
        /// </summary>
        public string Title => title;

        public string Author => author;

        public string Song => song;

        public IEnumerable<UnrealActor> Actors => actors;

        public IEnumerable<UnrealBrush> Brushes => brushes;

        public int ActorCount => actorCount;

        public int BrushCount => brushCount;

        public void AddActor(UnrealActor actor)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is a source file");
            else
            {
                if (actor is UnrealBrush)
                {
                    if ((actor as UnrealBrush).Polygons.Count() == 0)
                        // This brush is invalid
                        return;

                    brushes.Add(actor as UnrealBrush);
                    brushCount++;
                }
                actors.Add(actor);
                actorCount++;
            }
        }

        #region Intelligence

        public void RemoveTrappedPlayerStarts()
        {
            // TODO
        }

        public Point3D GetCenterOfGravity()
        {
            // TODO
            return new Point3D(0.0, 0.0, 0.0);
        }

        #endregion

        #region Text handling

        protected override string generateText()
        {
            return T3DParser.GenerateText(actors);
        }

        protected override void loadText(string text)
        {
            foreach (var actor in T3DParser.LoadActors(text))
                AddActor(actor);
            loadInfo();
        }

        private void loadInfo()
        {
            var levelInfo = Actors.Where(a => a.Class == "LevelInfo").FirstOrDefault();
            if (levelInfo != null)
            {
                title = levelInfo.GetProperty("Title");
                author = levelInfo.GetProperty("Author");
                song = levelInfo.GetProperty("Song");
            }
        }

        #endregion
    }
}
