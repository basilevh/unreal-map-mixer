// 20-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.Unreal;

namespace UnrealMapMixer.Mixers
{
    /// <summary>
    /// UnrealMap mixer that merges multiple maps with the original brush orders intact,
    /// but where no rules exist across different source maps.
    /// TODO: work out randomness to ensure that it's not too similar to OrderedMapMixer
    /// </summary>
    public class ShuffledMapMixer : MapMixer
    {
        public ShuffledMapMixer(IEnumerable<UnrealMap> maps) : base(maps)
        { }

        public override UnrealMap Mix(MapMixParams mixParams)
        {
            throw new NotImplementedException();
        }
    }
}
