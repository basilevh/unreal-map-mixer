// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Mixers
{
    /// <summary>
    /// UnrealMap mixer that merges multiple maps with all brush orders randomized.
    /// There are no intra-map or inter-map rules.
    /// </summary>
    public class ShuffledMapMixer : MapMixer
    {
        public ShuffledMapMixer(IEnumerable<UnrealMap> maps) : base(maps)
        { }

        public override UnrealMap Mix(MapMixParams mixParams)
        {
            var destMap = new UnrealMap();

            // Get all actors
            var allActors = new List<UnrealActor>();
            foreach (var map in maps)
            {
                Vector3D offset;
                if (mixParams.TranslateCommonCOG)
                {
                    var cog = map.CalcCenterOfGravity();
                    offset = new Vector3D(-cog.X, -cog.Y, -cog.Z);
                }
                else
                    offset = new Vector3D();
                allActors.AddRange(map.Actors.Select(a => a.Duplicate(offset)));
            }

            // Pick actors randomly
            var mixActors = new List<UnrealActor>();
            foreach (var actor in allActors)
            {
                // Check exclusions
                if (mixParams.ExcludeZoneInfo && ZoneInfoNames.Contains(actor.Class))
                    continue;
                if (mixParams.ExcludeMore && mixParams.ExcludeMoreNames.Contains(actor.Class))
                    continue;

                // Get probability
                double prob;
                if (actor.Class.Contains("Light"))
                    prob = mixParams.LightProb;
                else
                    prob = mixParams.OtherProb;

                if (randExp(prob))
                    mixActors.Add(actor);
            }

            // Shuffle
            shuffle(mixActors);

            // Add selected actors
            foreach (var actor in mixActors)
                destMap.AddActor(actor);

            // Remove trapped PlayerStarts
            if (mixParams.RemoveTrappedPlayerStarts)
                destMap.RemoveTrappedPlayerStarts();

            return destMap;
        }

        private static void shuffle<T>(IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
                swap(list, i, rnd.Next(i, list.Count));
        }

        private static void swap<T>(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
