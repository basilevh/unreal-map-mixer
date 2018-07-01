// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Mixers
{
    public abstract class MapMixer : IMapMixer
    {
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

        public abstract UnrealMap Mix(MapMixParams mixParams);
    }
}
