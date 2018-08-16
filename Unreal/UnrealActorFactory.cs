// 18-01-2018, BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnrealMapMixer.MyMath;

namespace UnrealMapMixer.Unreal
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

        /// <summary>
        /// Creates a modifiable deep copy of an actor, retaining the class type.
        /// </summary>
        public static UnrealActor Duplicate(UnrealActor actor)
        {
            if (actor is UnrealBrush)
                return (actor as UnrealBrush).Duplicate();
            else
                return actor.Duplicate();
        }

        /// <summary>
        /// Creates a copy of an actor, translated by the given offset.
        /// </summary>
        public static UnrealActor Duplicate(UnrealActor actor, Vector3D translateOffset)
        {
            var result = Duplicate(actor);
            if (!translateOffset.IsZero())
                result.Translate(translateOffset);
            return result;
        }

        /// <summary>
        /// Creates a modifiable deep copy of a brush.
        /// </summary>
        public static UnrealBrush Duplicate(UnrealBrush brush)
        {
            return brush.Duplicate();
        }

        /// <summary>
        /// Creates a copy of a brush, translated by the given offset.
        /// </summary>
        public static UnrealBrush Duplicate(UnrealBrush brush, Vector3D translateOffset)
        {
            var result = Duplicate(brush);
            if (!translateOffset.IsZero())
                result.Translate(translateOffset);
            return result;
        }
    }
}
