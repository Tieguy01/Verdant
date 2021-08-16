﻿using System;
using Microsoft.Xna.Framework.Graphics;

namespace IsoEngine
{
    public class Particle : Entity
    {

        int lifetime;

        /// <summary>
        /// Initialize a new Particle.
        /// </summary>
        /// <param name="sprite">The Particle's sprite.</param>
        /// <param name="pos">The position of the Particle.</param>
        /// <param name="w">The width of the Particle.</param>
        /// <param name="h">The height of the Particle.</param>
        /// <param name="lifetime">The number of frames the Particle should live before being marked as dead.</param>
        public Particle(RenderObject sprite, Vec2 pos, int w, int h, int lifetime) : base(sprite, pos, w, h)
        {
            this.lifetime = lifetime;
            hasPhysics = true;
        }

        public override void Update()
        {
            lifetime--;
            if (lifetime <= 0)
                return;
            base.Update();
        }

        public bool IsDead()
        {
            return lifetime <= 0;
        }

    }
}
