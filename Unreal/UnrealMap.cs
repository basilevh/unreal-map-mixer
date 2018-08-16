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
            FilePath = "N/A"; // a map created inside this program never has a file path
            title = "New UMM Map"; // can be changed later
        }

        protected UnrealMap(UnrealMap map) : base(map)
        {
            FilePath = map.FilePath;
            title = map.title;
            author = map.author;
            song = map.song;
            Type = map.Type;
            // Duplicate actors sequentially; brushes and ownership will be handled correctly this way
            foreach (var actor in map.Actors)
                AddActor(UnrealActorFactory.Duplicate(actor));
        }

        protected UnrealMap(string fileName, string text) : base(text)
        {
            this.FilePath = fileName;
        }

        /// <summary>
        /// Creates a modifiable deep copy of this map.
        /// </summary>
        public UnrealMap Duplicate() => new UnrealMap(this);

        /// <summary>
        /// Creates a read-only instance of an existing map.
        /// </summary>
        /// <param name="path">Full path of the T3D file to be parsed</param>
        public static UnrealMap FromFile(string path)
        {
            string text = File.ReadAllText(path);
            return new UnrealMap(path, text);
        }

        private UnrealActor levelInfo;
        private string title; // excluding quotes
        private string author; // excluding quotes
        private string song; // excluding Music'...'
        private List<UnrealActor> actors = new List<UnrealActor>();
        private List<UnrealBrush> brushes = new List<UnrealBrush>();

        public string FilePath { get; }

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
                    levelInfo.SetProperty("Title", value); // TODO: correct
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
                    levelInfo.SetProperty("Author", value); // TODO: correct
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
                    levelInfo.SetProperty("Song", value); // TODO: correct
                    textDirty = true;
                }
            }
        }

        public MapType Type { get; private set; } = MapType.Unknown;

        public IEnumerable<UnrealActor> Actors => actors;

        public IEnumerable<UnrealBrush> Brushes => brushes;

        public int ActorCount => actors.Count;

        public int BrushCount => brushes.Count;

        public void AddActor(UnrealActor actor)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");
            else
            {
                if (actor is UnrealBrush)
                // if (actor.Class == "Brush" || actor.Class == "Mover") // TODO: test
                {
                    if ((actor as UnrealBrush).Polygons.Count() == 0)
                        // This brush is invalid, so ignore it
                        return;

                    brushes.Add(actor as UnrealBrush);
                }
                actors.Add(actor);
                actor.Owner = this;
            }
        }

        public void RemoveActor(UnrealActor actor)
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");
            else
            {
                if (actor is UnrealBrush)
                    brushes.Remove(actor as UnrealBrush);
                actors.Remove(actor);
                actor.Owner = null;
            }
        }

        #region Intelligence

        /// <summary>
        /// Removes all PlayerStart actors that are not encompassed by any subtracting brush.
        /// </summary>
        public void RemoveTrappedPlayerStarts()
        {
            if (isReadOnly)
                throw new InvalidOperationException("This map cannot be modified because it is read-only");
            else
            {
                // TODO: this is not the way to do it; brushes may be added and/or subtracted afterwards etc.
                actors.RemoveAll(a => a.Class == "PlayerStart"
                    && brushes.All(b => b.Operation != BrushOperation.Subtract
                    || b.Encompasses(a, 24.0) == false));
            }
        }

        /// <summary>
        /// Calculates the volume-weighted center of gravity of this map by considering the encompassing cuboids of all brushes.
        /// </summary>
        public Point3D CalcCenterOfGravity()
        {
            double x = 0.0;
            double y = 0.0;
            double z = 0.0;
            double sumVol = 0.0;
            foreach (var brush in brushes)
            {
                double curVol = brush.GetVolumeUpperBound();
                x += (brush.GetXMax() + brush.GetXMin()) / 2.0 * curVol;
                y += (brush.GetYMax() + brush.GetYMin()) / 2.0 * curVol;
                z += (brush.GetZMax() + brush.GetZMin()) / 2.0 * curVol;
                sumVol += curVol;
            }
            return new Point3D(x / sumVol, y / sumVol, z / sumVol);
        }

        private void loadType()
        {
            // TODO: implement heuristic that checks for a big subtracted brush
            Type = MapType.Unknown;
        }

        #endregion

        #region Text handling

        protected override string GenerateText()
        {
            return T3DParser.GenerateText(this);
        }

        protected override void LoadText(string text)
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
