// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    /// <summary>
    /// UnrealMap mixer that merges multiple maps in a deterministic order. Every brush
    /// is assigned a normalized priority, and the resulting map is constructed
    /// from the interweaved list, sorted by priority.
    /// </summary>
    public class OrderedMapMixer : MapMixer
    {
        private static Random rnd = new Random();

        public OrderedMapMixer(IEnumerable<UnrealMap> maps) : base(maps)
        { }

        public override UnrealMap Mix(MapMixParams mixParams)
        {
            var finalMap = new UnrealMap();

            // Get brush-priority pairs & actors
            var brushPrios = new List<Tuple<UnrealBrush, double>>();
            var allActors = new List<UnrealActor>(); // excluding brushes
            foreach (var map in maps)
            { 
                brushPrios.AddRange(map.Brushes.Select(
                        (b, i) => new Tuple<UnrealBrush, double>
                        (b, (double)i / map.BrushCount)));
                allActors.AddRange(map.Actors.Where(a => !(a is UnrealBrush)));
            }

            // Merge all brushes
            var allBrushes = brushPrios.OrderBy(t => t.Item2).Select(t => t.Item1);

            // Pick brushes randomly
            var mixBrushes = new List<UnrealBrush>();
            foreach (var brush in allBrushes)
            {
                // Check exclusions
                if (mixParams.ExcludeInvisible && brush.IsInvisible)
                    continue;
                if (mixParams.ExcludePortal && brush.IsPortal)
                    continue;

                // TODO bug with exclusions?
                // TODO add tests!

                // Get probability
                double prob;
                switch (brush.Type)
                {
                    case BrushType.Solid: prob = mixParams.SolidChance; break;
                    case BrushType.SemiSolid: prob = mixParams.SemiSolidChance; break;
                    case BrushType.NonSolid: prob = mixParams.NonSolidChance; break;
                    case BrushType.Subtract: prob = mixParams.SubtractChance; break;
                    case BrushType.Mover: prob = mixParams.MoverChance; break;
                    default: prob = 0.0; break;
                }

                if (genRand(prob))
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
                double prob;
                if (actor.Class == "Light")
                    prob = mixParams.LightChance;
                else
                    prob = mixParams.OtherChance;

                if (genRand(prob))
                    mixActors.Add(actor);
            }

            // Add selected brushes & actors
            foreach (var brush in mixBrushes)
                finalMap.AddActor(brush);
            foreach (var actor in mixActors)
                finalMap.AddActor(actor);

            return finalMap;
        }

        private static bool genRand(double probTrue) => (rnd.NextDouble() < probTrue);
    }
}
