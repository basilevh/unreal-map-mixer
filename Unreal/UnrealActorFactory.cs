// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    public static class UnrealActorFactory
    {
        /// <summary>
        /// Instantiates an actor with the correct type.
        /// </summary>
        public static UnrealActor FromText(string text)
        {
            if ((text.StartsWith("Begin Actor Class=Brush ")
                || text.StartsWith("Begin Actor Class=Mover "))
                && text.Contains("Begin Brush ")) // some "Brushes" do not contain geometry, no idea why
                return UnrealBrush.FromText(text);
            else
                return UnrealActor.FromText(text);
        }
    }
}
