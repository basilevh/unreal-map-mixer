﻿// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    /// <summary>
    /// Holds all parameters to pass to a MapMixer.
    /// </summary>
    public struct MapMixParams
    {
        // Intelligence
        public bool RemoveTrappedPlayerStarts;
        public bool TranslateCommonCOG;
        public bool KeepEventTagLinks;
        public bool KeepWorldConnections;
        public bool ExpandPortals;

        // Probabilities
        public double SolidProb, SemiSolidProb, NonSolidProb,
            SubtractProb, MoverProb, LightProb, OtherProb;

        // Excluded actors
        public bool ExcludeInvisible, ExcludePortal, ExcludeZoneInfo, ExcludeMore;
        public IEnumerable<string> ExcludeMoreNames;
    }
}