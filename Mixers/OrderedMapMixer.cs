// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;

namespace UnrealMapMixer
{
    /// <summary>
    /// UnrealMap mixer that merges multiple maps in a deterministic order. Every brush
    /// is assigned a normalized rank, and the resulting map is constructed
    /// from the interweaved list, sorted by rising ranks.
    /// </summary>
    public class OrderedMapMixer : MapMixer
    {
        private static Random rnd = new Random();

        public OrderedMapMixer(IEnumerable<UnrealMap> maps) : base(maps)
        { }

        public override UnrealMap Mix(MapMixParams mixParams)
        {
            var destMap = new UnrealMap();

            // Get brush-rank pairs, actors and other features
            var brushRanks = new List<Tuple<UnrealBrush, double>>();
            var allActors = new List<UnrealActor>(); // excluding brushes
            var cogDict = new Dictionary<UnrealMap, Point3D>();
            foreach (var map in maps)
            { 
                brushRanks.AddRange(map.Brushes.Select(
                        (b, i) => new Tuple<UnrealBrush, double>
                        (b, (double)i / map.BrushCount)));
                allActors.AddRange(map.Actors.Where(a => !(a is UnrealBrush)));
                cogDict[map] = map.GetCenterOfGravity();
            }

            // Merge all brushes
            var allBrushes = brushRanks.OrderBy(t => t.Item2).Select(t => t.Item1);

            // Pick brushes randomly
            var mixBrushes = new List<UnrealBrush>();
            foreach (var brush in allBrushes)
            {
                // Check exclusions
                if (mixParams.ExcludeInvisible && brush.IsInvisible)
                    continue;
                if (mixParams.ExcludePortal && brush.IsPortal)
                    continue;

                // TODO: bug with exclusions?
                // TODO: add tests!

                // Get probability
                double prob;
                switch (brush.Type)
                {
                    case BrushType.Solid: prob = mixParams.SolidProb; break;
                    case BrushType.SemiSolid: prob = mixParams.SemiSolidProb; break;
                    case BrushType.NonSolid: prob = mixParams.NonSolidProb; break;
                    case BrushType.Subtract: prob = mixParams.SubtractProb; break;
                    case BrushType.Mover: prob = mixParams.MoverProb; break;
                    default: prob = 0.0; break;
                }
                
                if (randExp(prob))
                    mixBrushes.Add(brush);
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
                // TODO: not all lights are of class 'Light'
                double prob;
                if (actor.Class == "Light")
                    prob = mixParams.LightProb;
                else
                    prob = mixParams.OtherProb;

                if (randExp(prob))
                    mixActors.Add(actor);
            }

            // Add selected brushes & actors
            foreach (var brush in mixBrushes)
                destMap.AddActor(brush);
            foreach (var actor in mixActors)
                destMap.AddActor(actor);

            // Remove trapped PlayerStarts
            if (mixParams.RemoveTrappedPlayerStarts)
                destMap.RemoveTrappedPlayerStarts();

            return destMap;
        }

        /// <summary>
        /// Runs a random experiment with a boolean outcome.
        /// </summary>
        private static bool randExp(double probTrue) => (rnd.NextDouble() < probTrue);
    }
}
