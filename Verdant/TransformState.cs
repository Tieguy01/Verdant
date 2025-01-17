﻿using System;

namespace Verdant
{
    /// <summary>
    /// Modifies the way an Entity, Particle, etc. is rendered to the screen.
    /// Effect can be either multiplicative (a.k.a "relative", Multiply=true) or absolute (Multiply=false).
    /// </summary>
    public class TransformState
    {

        // Determines if the TransformState's properties should have a multiplicative effect.
        public bool Multiply { get; private set; } = true;

        // The position of the TransformState.
        public Vec2 Position { get; set; }
        // The width of the TransformState.
        public float Width { get; set; }
        // The height of the TransformState.
        public float Height { get; set; }
        // The rotation angle of the TransformState.
        public float Angle { get; set; }

        /// <summary>
        /// Initialize a new TransformState.
        /// By default, its properties will be initialized to not have any effect
        /// (accounting for if the TransformState is multiplicative).
        /// </summary>
        /// <param name="mutliply">Determines if the TransformState should have a multiplicative effect.</param>
        public TransformState(bool mutliply = true)
        {
            Multiply = mutliply;

            // defaults to 1 if multiplicative
            if (Multiply)
            {
                Position = new Vec2(1, 1);
                Width = 1;
                Height = 1;
                Angle = 1;
            }
        }

        /// <summary>
        /// Initialize a new TransformState.
        /// </summary>
        /// <param name="position">The position of the TransformState.</param>
        /// <param name="width">The width of the TransformState.</param>
        /// <param name="height">The height of the TransformState.</param>
        /// <param name="angle">The rotation angle of the TransformState.</param>
        /// <param name="multiply">Determiens if the TransformState should have a multiplicative effect.</param>
        public TransformState(Vec2 position, float width, float height, float angle, bool multiply = true)
        {
            Position = position;
            Width = width;
            Height = height;
            Angle = angle;
            Multiply = multiply;
        }

        /// <summary>
        /// Create a new TransformState with the same properties as this one.
        /// </summary>
        /// <returns>A new TransformState.</returns>
        public TransformState Copy()
        {
            TransformState newState = new(Multiply);
            newState.Position = Position.Copy();
            newState.Width = Width;
            newState.Height = Height;
            newState.Angle = Angle;
            return newState;
        }

        public static TransformState operator +(TransformState a, TransformState b) => new TransformState(a.Position + b.Position, a.Width + b.Width, a.Height + b.Height, a.Angle + b.Angle);
        public static TransformState operator -(TransformState a, TransformState b) => new TransformState(a.Position - b.Position, a.Width - b.Width, a.Height - b.Height, a.Angle - b.Angle);
        public static TransformState operator *(TransformState a, TransformState b) => new TransformState(a.Position * b.Position, a.Width * b.Width, a.Height * b.Height, a.Angle * b.Angle);
        public static TransformState operator /(TransformState a, TransformState b) => new TransformState(a.Position / b.Position, a.Width / b.Width, a.Height / b.Height, a.Angle / b.Angle);

    }
}
