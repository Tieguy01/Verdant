﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace IsoEngine.UI
{
    public class UISprite : UIElement
    {
        
        Texture2D[,] sprites;
        int spriteX = 0;
        int spriteY = 0;

        public UISprite(Sprite sprite, Vec2 pos) : base(pos, sprite.Width, sprite.Height)
        {
            sprites = new Texture2D[,] { { sprite.Get() } };
        }
        public UISprite(Sprite sprite, Vec2 pos, int w, int h) : base(pos, w, h)
        {
            sprites = new Texture2D[,] { { sprite.Get() } };
        }
        public UISprite(SpriteSheet sheet, Vec2 pos) : base(pos, sheet.Get().Width, sheet.Get().Height)
        {
            sprites = sheet.GetFullSheet();
        }
        public UISprite(SpriteSheet sheet, Vec2 pos, int w, int h) : base(pos, w, h)
        {
            sprites = sheet.GetFullSheet();
        }

        public void SetSpriteX(int x)
        {
            spriteX = x;
            spriteY = 0;
        }

        public void SetSpriteCoords(int x, int y)
        {
            spriteX = x;
            spriteY = y;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprites[spriteX, spriteY],
                new Rectangle(
                    (int)(Position.X * Renderer.Scale),
                    (int)(Position.Y * Renderer.Scale),
                    Width * Renderer.Scale,
                    Height * Renderer.Scale),
                Color.White);
        }

    }
}
