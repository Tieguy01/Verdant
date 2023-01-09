﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Verdant
{
    /// <summary>
    /// A RenderObject that stores an entire texture sheet, indexed by X,Y coordinates.
    /// </summary>
    public class SpriteSheet : RenderObject
    {

        protected Texture2D[,] sprites;

        /// <summary>
        /// Initialize a new SpriteSheet.
        /// </summary>
        /// <param name="sheetTexture">The Texture2D sheet of sprites. Sprites should be in one row, ordered left to right.</param>
        /// <param name="spriteW">The width of each sprite.</param>
        /// <param name="graphicsDevice">The GraphicsDevice to use when cropping.</param>
        public SpriteSheet(Texture2D sheetTexture, int spriteW)
        {
            sprites = BuildTexture2DArray(sheetTexture, spriteW, sheetTexture.Height);
        }
        /// <summary>
        /// Initialize a new 2D SpriteSheet.
        /// </summary>
        /// <param name="sheetTexture">The Texture2D sheet of sprites. Sprites should be in a 2D grid of uniform rows and columns.</param>
        /// <param name="spriteW">The width of each sprite.</param>
        /// <param name="spriteH">The height of each sprite.</param>
        /// <param name="graphicsDevice">The GraphicsDevice to use when cropping.</param>
        public SpriteSheet(Texture2D sheetTexture, int spriteW, int spriteH)
        {
            sprites = BuildTexture2DArray(sheetTexture, spriteW, spriteH);
        }
        /// <summary>
        /// Initialize a new SpriteSheet from an existing array of Texture2Ds.
        /// </summary>
        /// <param name="sprites">The array of Texture2Ds to use.</param>
        public SpriteSheet(Texture2D[,] sprites)
        {
            this.sprites = sprites;
        }

        /// <summary>
        /// Crop a single Texture2D sheet into a 2D array of sprites.
        /// </summary>
        /// <param name="sheetTexture">The Texture2D sheet of sprites.</param>
        /// <param name="spriteW">The width of each sprite in the sheet.</param>
        /// <param name="spriteH">The height of each sprite in the sheet.</param>
        /// <returns>A 2D array of all Texture2D sprites in the sheet.</returns>
        public static Texture2D[,] BuildTexture2DArray(Texture2D sheetTexture, int spriteW, int spriteH)
        {

            int sheetW = sheetTexture.Width / spriteW;
            int sheetH = sheetTexture.Height / spriteH;

            Texture2D[,] sprites = new Texture2D[sheetW, sheetH];

            for (int i = 0; i < sheetW; i++)
            {
                for (int j = 0; j < sheetH; j++)
                {
                    //crop frame from sheet
                    Texture2D slice = new Texture2D(Renderer.GraphicsDevice, spriteW, spriteH);
                    Color[] colorData = new Color[spriteW * spriteH];
                    sheetTexture.GetData(0, new Rectangle(i * spriteW, j * spriteH, spriteW, spriteH), colorData, 0, colorData.Length);
                    slice.SetData(colorData);
                    //add to array
                    sprites[i, j] = slice;
                }
            }

            return sprites;
        }

        /// <summary>
        /// Get the Texture2D of the sprite at the x position (and optionally y position) on the sheet.
        /// </summary>
        /// <param name="x">The x position of the sprite.</param>
        /// <param name="y">The y position of the sprite. Defaults to 0 (first row).</param>
        /// <returns>The Texture2D sprite located at the given coordinates.</returns>
        public override Texture2D DrawIndex(int x, int y = 0)
        {
            return sprites[x, y];
        }

        /// <summary>
        /// Get a Sprite representing the Texture2D at the x position (and optionally y position) on the sheet.
        /// NOTE: This function creates a new Sprite every time it is called, use DrawIndex() in a loop.
        /// </summary>
        /// <param name="x">The x position of the sprite.</param>
        /// <param name="y">The y position of the sprite.</param>
        /// <returns>A Sprite of the Texture2D located at the given coordinates.</returns>
        public Sprite GetSprite(int x, int y = 0)
        {
            return new Sprite(sprites[x, y]);
        }

        /// <summary>
        /// Get the first sprite on the sheet. SpriteSheet is intended to be used with DrawIndex.
        /// </summary>
        /// <returns>The Texture2D sprite located at (0, 0) on the sheet.</returns>
        public override Texture2D Draw()
        {
            return DrawIndex(0, 0);
        }

        /// <summary>
        /// Get width of the sheet (the number of columns of sprites).
        /// </summary>
        /// <returns>The width of the sheet.</returns>
        public int GetSheetWidth()
        {
            return sprites.GetLength(0);
        }

        /// <summary>
        /// Get the height of the sheet (the number of rows of sprites).
        /// </summary>
        /// <returns>The height of the sheet.</returns>
        public int GetSheetHeight()
        {
            return sprites.GetLength(1);
        }

        /// <summary>
        /// Get a 2D array containing all sprites in the sheet.
        /// </summary>
        /// <returns>A 2D array of Texture2D sprites.</returns>
        public Texture2D[,] GetFullSheet()
        {
            return sprites;
        }
    }
}
