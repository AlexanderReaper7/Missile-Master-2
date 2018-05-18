using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    /// Class responsible for Player movement, drawing etc.
    /// </summary>
    internal class Player
    {
        /// <summary>
        ///     Rotation of player in radians
        /// </summary>
        private readonly float rotationRate = MathHelper.Pi / 128f; // TODO : Add upgrade levels to rotationRate

        private GraphicsDevice _graphics;

        private KeyboardState _keyboard;
        public float Acceleration;

        public CollidableObject CollidableObject;
        public Vector2 Direction;
        public Vector2 Velocity; // TODO : Make air-resistance and more fluid movement


        /// <summary>
        ///     Called upon to load player textures etc.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            _graphics = graphics;
            CollidableObject = new CollidableObject(content.Load<Texture2D>(@"images/V-2"), new Vector2(100, 200), 0.0f);

            // Logging statement
            Console.WriteLine("Player Loaded");
        }

        public void Update(GameTime gameTime)
        {
            // Run Player Controls to update acceleration and rotation
            Controls();
            // Get new direction
            Direction = new Vector2((float)Math.Cos(CollidableObject.Rotation), (float)Math.Sin(CollidableObject.Rotation));
            // Get new velocity
            Velocity += Direction * Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO : Edge Collision

            // TODO : Object collision using CollidableObject class

            // TODO : fix hiccup during moving away from border

            //if (CollidableObject.Position.X > Game1.ScreenBounds.X / 2 + 5 && CollidableObject.Position.X < Game1.ScreenBounds.X - 5)
            //{
            //    InGame.MoveBackground(new Vector2(Velocity.X, 0));
            //}

            //if (CollidableObject.Position.Y > Game1.ScreenBounds.Y / 2 + 5 && CollidableObject.Position.Y < Game1.ScreenBounds.Y - 5)
            //{
            //    InGame.MoveBackground(new Vector2(0, Velocity.Y));
            //}


            // Moves Background
            InGame.MoveBackground(Velocity);

            // Update position
            // If player reaches a place where the background no longer can move any further along the X-axis,
            if (InGame.MovableBackground1.IsSourceMaxX || InGame.MovableBackground1.IsSourceMinX) // TODO : Make Movable background depend on current level
            {
                // Then move player itself instead of background,
                CollidableObject.Position.X += Velocity.X;
            }
            else
            {
                // Else move player to center of screen X-axis.
                CollidableObject.Position.X = Game1.ScreenBounds.X / 2;
            }

            // If player reaches a place where the background no longer can move any further along the Y-axis, 
            if (InGame.MovableBackground1.IsSourceMaxY || InGame.MovableBackground1.IsSourceMinY)
            {
                // Then move player itself instead of background,
                CollidableObject.Position.Y += Velocity.Y;
            }
            else
            {
                // Else move player to center of screen Y-axis.
                CollidableObject.Position.Y = Game1.ScreenBounds.Y / 2;
            }

            // Slowdown
            Acceleration *= 0.90f;
            Velocity *= 0.95f;

            // TODO : change Acceleration stopping
            if (Acceleration < 0.1)
            {
                Acceleration = 0;
            }
        }


        /// <summary>
        ///     keyboard controls for InGame
        /// </summary>
        private void Controls()
        {
            // Get keyboard state
            _keyboard = Keyboard.GetState();

            // If W or Up arrow is key pressed down
            if (_keyboard.IsKeyDown(Keys.W) || _keyboard.IsKeyDown(Keys.Up))
            {
                // Activate main thruster increasing acceleration
                Acceleration += 3;
                // TODO : Add fuel usage
            }

            // If A or Left arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.A) || _keyboard.IsKeyDown(Keys.Left))
            {
                // Activate right side thrusters, rotating counter-clockwise
                CollidableObject.Rotation -= rotationRate;
            }

            // If S or Down arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.S) || _keyboard.IsKeyDown(Keys.Down))
            {
                // Activate counter thrusters decreasing acceleration
                Acceleration -= 1;
            }

            // If D or Right arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.D) || _keyboard.IsKeyDown(Keys.Right))
            {
                // Activate left side thrusters, rotating clockwise
                CollidableObject.Rotation += rotationRate;
            }
        }

        /// <summary>
        ///     Draw Player
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, Color.White, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}