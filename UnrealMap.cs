// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    /// <summary>
    /// Represents a game level in Unreal Engine.
    /// </summary>
    public class UnrealMap
    {
        #region Constructors

        /// <summary>
        /// Creates a new modifiable map.
        /// </summary>
        public UnrealMap()
        {
            isReadOnly = false;
            text = null;
            textDirty = true;
            title = "New UMM Map";
            author = null;
            song = null;
            actors = new List<UnrealActor>();
            brushes = new List<UnrealBrush>();
            actorCount = 0;
            brushCount = 0;
        }

        /// <summary>
        /// Creates a modifiable copy of an existing map.
        /// </summary>
        /// <param name="map">Map to be duplicated</param>
        public UnrealMap(UnrealMap map) : this()
        {
            text = map.text;
            textDirty = map.textDirty;
            title = map.title;
            author = map.author;
            song = map.song;
            actors.AddRange(map.Actors);
            brushes.AddRange(map.Brushes);
            actorCount = map.actorCount;
            brushCount = map.brushCount;
        }
        
        private UnrealMap(string text) : this()
        {
            // Parse text
            loadText(text);
            // Now make it read-only
            isReadOnly = true;
            // Store original text
            this.text = text;
            textDirty = false;
        }

        /// <summary>
        /// Creates a read-only instance of a map.
        /// </summary>
        /// <param name="text">Text representation of the map</param>
        public static UnrealMap FromText(string text) => new UnrealMap(text);

        #endregion

        private bool isReadOnly;
        private string text;
        private bool textDirty; // whether 'text' must be updated before being returned
        private string title;
        private string author;
        private string song;
        private List<UnrealActor> actors;
        private List<UnrealBrush> brushes;
        private int actorCount;
        private int brushCount;

        #region Public fields

        /// <summary>
        /// The file content for this map. This can be either the original text or newly generated text.
        /// </summary>
        public string Text
        {
            get
            {
                if (textDirty)
                { 
                    text = generateText();
                    textDirty = false;
                }
                return text;
            }
        }

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
                throw new InvalidOperationException("This map cannot be modified since it is read from a file");
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

        #endregion

        #region Text handling

        /* T3D Map Format:
         * Begin Map
         * Begin Actor Class=... Name=...
         *     Property=Value
         *     ...
         * End Actor
         * ...
         * End Map
         */

        private void loadText(string text)
        {
            loadInfo(text);
            loadActors(text);
        }

        private void loadInfo(string text)
        {
            int start = text.IndexOf("Begin Actor Class=LevelInfo ");
            start = text.IndexOf("Title=", start);
            // TODO
            title = "";
            author = "";
            song = "";
        }

        private void loadActors(string text)
        {
            int start = text.IndexOf("Begin Actor "); ;
            while (start != -1)
            {
                // Get length of this block
                int end = text.IndexOf("End Actor", start) + "End Actor".Length;
                int length = end - start;

                // Extract and add actor
                string actorText = text.Substring(start, length);
                var actor = UnrealActorFactory.FromText(actorText);
                AddActor(actor); // increments actorCount and brushCount as necessary

                // Next iteration
                start = text.IndexOf("Begin Actor ", end);
            }
        }

        private string generateText()
        {
            var builder = new StringBuilder();

            // Add header
            builder.AppendLine("Begin Map");
            // Add all actors
            foreach (var actor in actors)
                builder.AppendLine(actor.Text);
            // Add footer
            builder.AppendLine("End Map");

            return builder.ToString();
        }

        #endregion
    }
}
