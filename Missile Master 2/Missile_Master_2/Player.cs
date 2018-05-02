using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    class Player
    {
        #region Fields

        private GraphicsDevice graphics;
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position = new Vector2(100, 100);
        public Vector2 velocity; // TODO : Make air-resistance and more fluid movement
        public float acceleration;
        public Vector2 origin;
        public Vector2 direction;
        /// <summary>
        /// Rotation of player in radians
        /// </summary>
        float rotation;
        private float turnRate = MathHelper.Pi / 128f;

        private KeyboardState keyboard;

        private CollidableObject collision;

        #endregion


        /// <summary>
        /// Called upon
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            texture = content.Load<Texture2D>(@"images/V-2");
            this.graphics = graphics;

            collision = new CollidableObject(texture, position, rotation);
            // Logging statement
            Console.WriteLine("Player Loaded");
        }

        public void Update()
        {
            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            // Run Player Controlls
            Controlls();
            // Update position
            position += direction * acceleration;
            // 
            acceleration -= 0.33f;
        }


        private void Controlls()
        {
            // Get keyboard
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            {
                acceleration++;
            }

            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                rotation -= turnRate;
            }

            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                acceleration *= 0.6f;
            }

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                rotation += turnRate;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
