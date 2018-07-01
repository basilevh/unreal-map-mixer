// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer
{
    public enum MapType
    {
        Additive, Subtractive, Unknown
    }

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
        }

        protected UnrealMap(UnrealMap map) : base(map)
        {
            title = map.title;
            author = map.author;
            song = map.song;
            type = map.type;
            actors = map.actors.Select(a => a.Duplicate()).ToList();
            brushes = map.brushes.Select(b => b.Duplicate()).ToList();
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

        private UnrealActor levelInfo;
        private string title; // excluding quotes
        private string author; // excluding quotes
        private string song; // excluding Music'...'
        private MapType type = MapType.Unknown;
        private List<UnrealActor> actors = new List<UnrealActor>();
        private List<UnrealBrush> brushes = new List<UnrealBrush>();
        private int actorCount = 0;
        private int brushCount = 0;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (isReadOnly)
                    throw new InvalidOperationException("This map cannot be modified because it is read-only");
                else
                {
                    title = value;
                    levelInfo.SetProperty("Title", value);
                    textDirty = true;
                }
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (isReadOnly)
                    throw new InvalidOperationException("This map cannot be modified because it is read-only");
                else
                {
                    author = value;
                    levelInfo.SetProperty("Author", value);
                    textDirty = true;
                }
            }
        }

        public string Song
        {
            get
            {
                return song;
            }
            set
            {
                if (isReadOnly)
                    throw new InvalidOperationException("This map cannot be modified because it is read-only");
                else
                {
                    title = value;
                    levelInfo.SetProperty("Song", value);
                    textDirty = true;
                }
            }
        }

        public MapType Type => type;

        public IEnumerable<UnrealActor> Actors => actors;

        public IEnumerable<UnrealBrush> Brushes => brushes;

        public int ActorCount => actorCount;

        public int BrushCount => brushCount;

        public void AddActor(UnrealActor actor)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");
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
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");
            else
            {
                // TODO
            }
        }

        public Point3D GetCenterOfGravity()
        {
            // TODO
            return new Point3D(0.0, 0.0, 0.0);
        }

        private void loadType()
        {
            // TODO: implement heuristic that checks for a big subtracted brush
            type = MapType.Unknown;
        }

        #endregion

        #region Text handling

        protected override string generateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void loadText(string text)
        {
            foreach (var actor in T3DParser.LoadActors(text))
                AddActor(actor);
            loadInfo();
            loadType();
        }

        #endregion

        private void loadInfo()
        {
            levelInfo = Actors.Where(a => a.Class == "LevelInfo").FirstOrDefault();
            if (levelInfo != null)
            {
                title = levelInfo.GetProperty("Title");
                title = title?.Substring(1, title.Length - 2);
                author = levelInfo.GetProperty("Author");
                author = author?.Substring(1, author.Length - 2);
                song = levelInfo.GetProperty("Song");
                song = song?.Substring(6, song.Length - 7);
            }
        }
    }
}
