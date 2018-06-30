// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public interface IMapMixer
    {
        UnrealMap Mix(MapMixParams mixParams);
    }
}
