// BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public class RandomMixer
    {
        private static Random rnd = new Random();

        public RandomMixer(string[] maps)
        {
            var orderedLists = new List<List<ActorPriority>>();
            
            foreach (string m in maps)
            {
                var curList = new List<ActorPriority>();
                int index = m.IndexOf("Begin Actor");
                int nextIndex = m.IndexOf("Begin Actor", index + 1);
                while (index != -1 && nextIndex != -1)
                {
                    curList.Add(new ActorPriority(Actor.Parse(m.Substring(index, nextIndex - index))));
                    index = nextIndex;
                    nextIndex = m.IndexOf("Begin Actor", index + 1);
                    if (nextIndex == -1)
                        nextIndex = m.IndexOf("End Map", index + 1);
                }

                int actorCount = curList.Count;
                for (int i = 0; i < actorCount; i++)
                    curList[i].Priority = (double)i / actorCount;

                orderedLists.Add(curList);
            }

            allActors = new List<Actor>();
            while (true)
            {
                double min = -1;
                List<ActorPriority> minPos = null;
                foreach (var l in orderedLists)
                    if (l.Count != 0 && l[0].Priority > min)
                    {
                        min = l[0].Priority;
                        minPos = l;
                    }
                if (min == -1)
                    break;
                allActors.Add(minPos[0].Actor);
                minPos.RemoveAt(0);
            }
        }
        
        private List<Actor> allActors;

        public string Generate(double brush, double light, double other, string[] excluded)
        {
            string result = "Begin Map" + Environment.NewLine;
            foreach (Actor a in allActors)
            {
                if (contains(excluded, a.Class))
                    continue;
                double chance = (a.Class == "Brush") ? brush : (a.Class == "Light") ? light : other;
                if (rnd.NextDouble() < chance)
                    result += a.GetFull() + Environment.NewLine;
            }
            result += "End Map";
            return result;
        }

        private bool contains(string[] source, string check)
        {
            foreach (string s in source)
                if (s == check)
                    return true;
            return false;
        }
    }
}
