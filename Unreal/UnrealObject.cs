using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer.Unreal
{
    /// <summary>
    /// Superclass of all relevant Unreal Engine objects.
    /// </summary>
    public abstract class UnrealObject
    {
        /// <summary>
        /// Creates a new modifiable object.
        /// </summary>
        public UnrealObject()
        { }

        /// <summary>
        /// Creates a modifiable deep copy of an existing object.
        /// </summary>
        /// <param name="orig">Object to be duplicated</param>
        protected UnrealObject(UnrealObject orig) : this()
        {
            text = orig.text;
            textDirty = orig.textDirty;
        }

        /// <summary>
        /// Creates a read-only instance of an object.
        /// </summary>
        /// <param name="text">T3D file contents to be parsed</param>
        protected UnrealObject(string text) : this()
        {
            // Parse text
            loadText(text);
            // Now make it read-only
            isReadOnly = true;
            // Store original text
            this.text = text;
            textDirty = false;
        }

        protected readonly bool isReadOnly = false;
        private string text;
        protected bool textDirty = true; // whether 'text' must be updated before being returned

        /// <summary>
        /// The file content for this map. This can be either the original text or newly generated text.
        /// </summary>
        public string Text
        {
            get
            {
                if (!isReadOnly && textDirty)
                {
                    text = generateText();
                    textDirty = false;
                }
                return text;
            }
        }

        protected abstract string generateText();

        protected abstract void loadText(string text);
    }
}
