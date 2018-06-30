// BVH

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnrealMapMixer
{
    class ActorPriority
    {
        public ActorPriority(Actor actor, double priority)
        {
            this.actor = actor;
            this.priority = priority;
        }

        public ActorPriority(Actor actor)
            : this(actor, 0)
        { }

        private Actor actor;
        private double priority;

        public Actor Actor
        {
            get
            {
                return actor;
            }
        }

        public double Priority
        {
            get
            {
                return priority;
            }
            set
            {
                priority = value;
            }
        }
    }
}
