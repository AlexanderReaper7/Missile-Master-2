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
        public Vector2 velocity; // TODO : Make air-resistance and more fluid movement
        public float acceleration;
        public Vector2 origin;
        public Vector2 direction;
        /// <summary>
        /// Rotation of player in radians
        /// </summary>
        private float rotationRate = MathHelper.Pi / 128f;

        private KeyboardState keyboard;

        private CollidableObject collidableObject;

        #endregion



        /// <summary>
        /// Called upon to load player textures etc.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            texture = content.Load<Texture2D>(@"images/V-2");
            this.graphics = graphics;

            origin = new Vector2(texture.Width / 2, texture.Height / 2);

            collidableObject = new CollidableObject(texture, new Vector2(100, 200), 0.0f);
            // Logging statement
            Console.WriteLine("Player Loaded");
        }

        double timer = 0;
        public void Update(GameTime gameTime)
        {
            // Get new direction
            direction = new Vector2((float)Math.Cos(collidableObject.Rotation), (float)Math.Sin(collidableObject.Rotation));

            timer += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer > 250)
            {
                timer = 0;

                Console.WriteLine("direction" + direction.ToString());
                Console.WriteLine("rotation" + collidableObject.Rotation.ToString());
                Console.WriteLine("acceleration" + acceleration.ToString());
                Console.WriteLine("position" + collidableObject.Position.ToString());
            }

            // Run Player Controlls
            Controlls();
            velocity += direction * acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            // Update position
            collidableObject.Position += velocity;
            // Slowdown
            acceleration *= 0.90f;
            velocity *= 0.9f;
            if (acceleration < 0.2)
            {
                acceleration = 0;
            }
        }


        /// <summary>
        /// keyboard controlls for ingame
        /// </summary>
        private void Controlls()
        {
            // Get keyboard
            keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            {
                acceleration++;
                // TODO : Add fuel usage
            }

            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            {
                collidableObject.Rotation -= rotationRate;
            }

            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            {
                // Brake
                acceleration *= 0.6f;
            }

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            {
                collidableObject.Rotation += rotationRate;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, collidableObject.Position, null, Color.White, collidableObject.Rotation, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
