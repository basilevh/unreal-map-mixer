using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    class Actor
    {
        public Actor(string _class, string _name, string _content)
        {
            this._class = _class;
            this._name = _name;
            this._content = _content;
        }

        private string _class, _name, _content;

        public static Actor Parse(string full)
        {
            string[] lines = full.Split('\n');
            int indexClass = lines[0].IndexOf("Class=");
            int indexName = lines[0].IndexOf("Name=");
            string c = lines[0].Substring(indexClass + 6, indexName - indexClass - 7);
            string n = lines[0].Substring(indexName + 5);
            /*int fullLength = lines[0].Length;
            int lastLine = 0;
            while (lines[lastLine] != "End Actor" && lastLine < lines.Length - 1)
            {
                lastLine++;
                fullLength += lines[lastLine].Length;
            }*/
            return new Actor(c, n, full.Substring(lines[0].Length + 1, full.Length - lines[0].Length - 12));
        }

        public string Class
        {
            get
            {
                return _class;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Content
        {
            get
            {
                return _content;
            }
        }

        public string GetFull()
        {
            return "Begin Actor Class=" + _class + " Name=" + _name + Environment.NewLine
                + _content + Environment.NewLine
                + "End Actor" + Environment.NewLine;
        }
    }
}
