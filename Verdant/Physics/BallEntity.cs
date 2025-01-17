﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Verdant.Physics
{
    /// <summary>
    /// An Entity with a Circle body.
    /// </summary>
    public class BallEntity : PhysicsEntity
    {

        private float radius;
        private int drawDiam;

        /// <summary>
        /// Initialize a new BallEntity.
        /// </summary>
        /// <param name="sprite">The Entity's sprite.</param>
        /// <param name="position">The position of the center of the Entity.</param>
        /// <param name="radius">The radius of the Entity's Ball. Also used to determine rendering width and height by default.</param>
        /// <param name="mass">The mass of the Entity's Body. 0 = infinite mass.</param>
        public BallEntity(RenderObject sprite, Vec2 position, float radius, float mass)
            : base(sprite, position, (int)(radius * 2), (int)(radius * 2), mass)
        {
            Components = new Shape[] { new Circle(position.X, position.Y, radius) };
            this.radius = radius;
            drawDiam = (int)(radius * 2);
        }

        /// <summary>
        /// Move according to WASD input.
        /// </summary>
        public void SimpleInput()
        {
            bool up = InputHandler.KeyboardState.IsKeyDown(Keys.W);
            bool down = InputHandler.KeyboardState.IsKeyDown(Keys.S);
            bool left = InputHandler.KeyboardState.IsKeyDown(Keys.A);
            bool right = InputHandler.KeyboardState.IsKeyDown(Keys.D);

            if (left) Acceleration.X = -Speed;
            if (up) Acceleration.Y = -Speed;
            if (right) Acceleration.X = Speed;
            if (down) Acceleration.Y = Speed;
            if (!left && !right) Acceleration.X = 0;
            if (!up && !down) Acceleration.Y = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Sprite == RenderObject.None) return;

            if (TransformState == null)
            {
                Sprite.Draw(spriteBatch,
                            Manager.Scene.Camera.GetRenderBounds(
                                Position - new Vec2(radius, radius),
                                drawDiam,
                                drawDiam
                                )
                            );
            }
            else
            {
                if (TransformState.Multiply)
                {
                    Sprite.Draw(spriteBatch,
                        Manager.Scene.Camera.GetRenderBounds(
                            (Position.X - (drawDiam * TransformState.Width/2)) * TransformState.Position.X,
                            (Position.Y - (drawDiam * TransformState.Height/2)) * TransformState.Position.Y,
                            drawDiam * TransformState.Width,
                            drawDiam * TransformState.Height
                            ));
                }
                else
                {
                    Sprite.Draw(spriteBatch,
                        Manager.Scene.Camera.GetRenderBounds(
                            (TransformState.Width / 2f) + TransformState.Position.X,
                            (TransformState.Height / 2f) + TransformState.Position.Y,
                            TransformState.Width,
                            TransformState.Height
                            ),
                        TransformState.Angle,
                        new Vector2(
                            TransformState.Width / 2,
                            TransformState.Height / 2
                            ));
                }
            }
        }
    }
}
