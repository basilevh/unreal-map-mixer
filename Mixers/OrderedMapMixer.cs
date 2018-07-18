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
    /// UnrealMap mixer that merges multiple maps in a deterministic order. Every brush
    /// is assigned a normalized rank, and the resulting map is constructed
    /// from the interweaved list, sorted by rising ranks.
    /// </summary>
    public class OrderedMapMixer : MapMixer
    {
        public OrderedMapMixer(IEnumerable<UnrealMap> maps) : base(maps)
        { }

        // TODO: DRY

        public override UnrealMap Mix(MapMixParams mixParams)
        {
            var destMap = new UnrealMap();

            // Get brush-rank pairs, actors and other features
            var brushRanks = new List<Tuple<UnrealBrush, double>>();
            var allActors = new List<UnrealActor>(); // excluding brushes
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

                brushRanks.AddRange(map.Brushes
                    .Select(
                        (b, i) => new Tuple<UnrealBrush, double>
                        (b.Duplicate(offset), (double)i / map.BrushCount)));

                allActors.AddRange(map.Actors
                    .Where(a => !(a is UnrealBrush))
                    .Select(a => a.Duplicate(offset)));
            }

            // Merge all brushes
            var allBrushes = brushRanks.OrderBy(t => t.Item2).Select(t => t.Item1);

            // Pick brushes randomly
            var mixBrushes = new List<UnrealBrush>();
            mixBrushes.Add(maps.First().Brushes.First()); // add builder brush
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
                switch (brush.Operation)
                {
                    case BrushOperation.Solid: prob = mixParams.SolidProb; break;
                    case BrushOperation.SemiSolid: prob = mixParams.SemiSolidProb; break;
                    case BrushOperation.NonSolid: prob = mixParams.NonSolidProb; break;
                    case BrushOperation.Subtract: prob = mixParams.SubtractProb; break;
                    case BrushOperation.Mover: prob = mixParams.MoverProb; break;
                    default: prob = 0.0; break; // probably builder brush, which is already included
                }

                if (RandExp(prob))
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
                if (actor.Class.Contains("Light"))
                    prob = mixParams.LightProb;
                else
                    prob = mixParams.OtherProb;

                if (RandExp(prob))
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
    }
}
