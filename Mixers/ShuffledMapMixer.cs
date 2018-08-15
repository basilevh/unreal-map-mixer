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

        // TODO: DRY

        protected override UnrealMap _Mix(MapMixParams mixParams)
        {
            var destMap = new UnrealMap();

            // Get all actors
            var allActors = new List<UnrealActor>();
            foreach (var map in maps)
            {
                var offset = mixParams.MapOffsets[map.FilePath];

                allActors.AddRange(map.Actors.Select(a => a.Duplicate(offset)));
            }

            // TODO: transfer brushes separately, otherwise they lose their UnrealBrush status!

            // Pick actors randomly
            var mixActors = new List<UnrealActor>();
            foreach (var actor in allActors)
            {
                // Check exclusions
                if (mixParams.ExcludeZoneInfo && ZoneInfoNames.Contains(actor.Class))
                    continue;
                if (mixParams.ExcludeMore && mixParams.ExcludeMoreNames.Contains(actor.Class))
                    continue;

                // TODO: check brush probabilities

                // Get probability
                double prob;
                if (actor.Class.Contains("Light"))
                    prob = mixParams.LightProb;
                else
                    prob = mixParams.OtherProb;

                if (RandExp(prob))
                    mixActors.Add(actor);
            }

            // Shuffle
            Shuffle(mixActors);

            // Add selected actors
            foreach (var actor in mixActors)
                destMap.AddActor(actor);

            // Remove trapped PlayerStarts
            if (mixParams.RemoveTrappedPlayerStarts)
                destMap.RemoveTrappedPlayerStarts();

            return destMap;
        }

        private static void Shuffle<T>(IList<T> list)
        {
            for (var i = 0; i < list.Count; i++)
                Swap(list, i, rnd.Next(i, list.Count));
        }

        private static void Swap<T>(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
