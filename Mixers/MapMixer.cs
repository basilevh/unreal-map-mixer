// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Mixers
{
    public abstract class MapMixer : IMapMixer
    {
        protected const double TranslateCOGStep = 64.0;

        // SkyZoneInfo and RockingSkyZoneInfo are still included
        public static readonly ReadOnlyCollection<string> ZoneInfoNames
            = new ReadOnlyCollection<string>(new[] {
                "ZoneInfo", "CloudZone", "JailZone",
                "PressureJailZone", "SlimeJailZone", "WaterJailZone",
                "JBArenaZone", "KillingField", "LavaZone",
                "LevelInfo", "NitrogenZone", "PressureZone",
                "SlimeZone",
                "TarZone", "TeleporterZone", "ToggleZoneInfo",
                "VacuumZone", "WarpZoneInfo", "WaterZone"
            });

        public MapMixer(IEnumerable<UnrealMap> maps)
        {
            this.maps = maps;
        }

        protected IEnumerable<UnrealMap> maps;

        public IEnumerable<UnrealMap> Maps => maps;

        public UnrealMap Mix(MapMixParams mixParams)
        {
            // Preprocess the parameters first

            // Fill in dictionaries to prevent exceptions
            foreach (var map in maps)
            {
                if (!mixParams.MapOffsets.ContainsKey(map.FilePath))
                    mixParams.MapOffsets[map.FilePath] = new Vector3D();
            }

            // If 'Translate to common COG' is enabled,
            // then override all map offsets with the relevant value.
            if (mixParams.TranslateCommonCOG)
            {
                foreach (var map in maps)
                {
                    var cog = map.CalcCenterOfGravity();
                    mixParams.MapOffsets[map.FilePath] = new Vector3D(-cog.X, -cog.Y, -cog.Z);
                }
                mixParams.TranslateCommonCOG = false; // considered done now
            }
            

            return _Mix(mixParams);
        }

        protected abstract UnrealMap _Mix(MapMixParams mixParams);

        protected static Random rnd = new Random();

        /// <summary>
        /// Runs a random experiment (binomial trial) with a boolean outcome.
        /// </summary>
        protected static bool RandExp(double probTrue) => (rnd.NextDouble() < probTrue);
    }
}
