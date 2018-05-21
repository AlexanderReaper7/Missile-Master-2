using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    ///     Class responsible for Player movement, drawing etc.
    /// </summary>
    internal class Player
    {
        private KeyboardState _keyboard;
        private bool _isMainThrusterActive;
        private Particle _mainThrusterParticle;
        private bool _colliding;
        private Vector2 _velocity; // TODO : Make air-resistance and more fluid movement
        public float Acceleration;
        public Vector2 Direction;
        public CollidableObject CollidableObject;
        private readonly float rotationRate = MathHelper.Pi / 128f; // TODO : Add upgrade levels to rotationRate
        public float MaxFuel = 50000;
        public float Fuel;
        /// <summary>
        ///     Called upon to load player textures etc.
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            CollidableObject = new CollidableObject(content.Load<Texture2D>(@"images/V-2"), new Vector2(100, 200), 0.0f);

            _mainThrusterParticle = new Particle(content.Load<Texture2D>(@"images/RocketFlameAnimationSpriteSheetCut"), new Rectangle((int)CollidableObject.Position.X - (int)CollidableObject.Origin.X, (int)CollidableObject.Position.Y, 30, CollidableObject.Texture.Height), new Rectangle(0, 0, 26, 13), new Vector2(CollidableObject.Texture.Height, 0), CollidableObject.Rotation, 150);

            Fuel = MaxFuel;
            // Logging statement
            Console.WriteLine("Player Loaded");
        }

        public void Update(GameTime gameTime)
        {
            // Run Player Controls to update acceleration and rotation
            Controls(gameTime);

            // Get new direction
            Direction = new Vector2((float)Math.Cos(CollidableObject.Rotation), (float)Math.Sin(CollidableObject.Rotation));

            // Get new velocity TODO: re-document and refine
            _velocity += Direction * Acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check for collisions to enemies
            _colliding = EnemyManager.CheckCollisionToPlayer();

            // TODO: Edge Collision

            // Moves Background along the X-axis when player is within 30 px of the screen center
            if (CollidableObject.Position.X > Game1.ScreenBounds.X / 2 - 15 && CollidableObject.Position.X < Game1.ScreenBounds.X / 2 + 15)
            {
                InGame.MoveBackground(new Vector2(_velocity.X, 0));
            }

            // Moves Background along the Y-axis when player is within 30 px of the screen center
            if (CollidableObject.Position.Y > Game1.ScreenBounds.Y / 2 - 15 && CollidableObject.Position.Y < Game1.ScreenBounds.Y / 2 + 15)
            {
                InGame.MoveBackground(new Vector2(0, _velocity.Y));
            }


            // Update position
            // If player reaches a place where the background no longer can move any further along the X-axis,
            if (InGame.MovableBackground1.IsSourceMaxX || InGame.MovableBackground1.IsSourceMinX) // TODO : Make Movable background depend on current level
            {
                // Then move the player itself instead of the background,
                CollidableObject.Position.X += _velocity.X;
            }
            else
            {
                // Else move player to center of screen along the X-axis.
                CollidableObject.Position.X = Game1.ScreenBounds.X / 2;
            }

            // If player reaches a place where the background no longer can move any further along the Y-axis, 
            if (InGame.MovableBackground1.IsSourceMaxY || InGame.MovableBackground1.IsSourceMinY)
            {
                // Then move the player itself instead of the background,
                CollidableObject.Position.Y += _velocity.Y;
            }
            else
            {
                // Else move player to center of screen along the Y-axis.
                CollidableObject.Position.Y = Game1.ScreenBounds.Y / 2;
            }

            // Slowdown
            Acceleration *= 0.90f;
            _velocity *= 0.95f;

            // TODO : change Acceleration stopping
            if (Acceleration < 0.1)
            {
                Acceleration = 0;
            }
        }

        public void Reset()
        {
            Fuel = MaxFuel;
        }

        private void AnimateMainThruster(GameTime gameTime)
        {
            // Set new position to _mainThrusterParticle
            _mainThrusterParticle.DestinationRectangle.X = (int)CollidableObject.Position.X - (int)CollidableObject.Origin.X;
            _mainThrusterParticle.DestinationRectangle.Y = (int)CollidableObject.Position.Y - (int)CollidableObject.Origin.Y;
            _mainThrusterParticle.Rotation = CollidableObject.Rotation;
            _mainThrusterParticle.Animate(gameTime);
        }


        /// <summary>
        ///     keyboard controls for InGame
        /// </summary>
        private void Controls(GameTime gameTime)
        {
            // Get keyboard state
            _keyboard = Keyboard.GetState();

            // If W or Up arrow is key pressed down
            if ((_keyboard.IsKeyDown(Keys.W) || _keyboard.IsKeyDown(Keys.Up)) && Fuel > 0)
            {
                // Activate main thruster increasing acceleration
                Acceleration += 3;

                // TODO : Add fuel usage
                // Use fuel
                Fuel--;
                // Activate thruster particles
                AnimateMainThruster(gameTime);
                _isMainThrusterActive = true;
            }
            else
            {
                _isMainThrusterActive = false;
            }

            // If A or Left arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.A) || _keyboard.IsKeyDown(Keys.Left))
            {
                // Activate right side thrusters or fins, rotating counter-clockwise
                CollidableObject.Rotation -= rotationRate * (float)gameTime.ElapsedGameTime.TotalSeconds * Acceleration + 0.005f;
            }

            // If S or Down arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.S) || _keyboard.IsKeyDown(Keys.Down))
            {
                // Activate counter thrusters decreasing acceleration
                
            }

            // If D or Right arrow key is pressed down
            if (_keyboard.IsKeyDown(Keys.D) || _keyboard.IsKeyDown(Keys.Right))
            {
                // Activate left side thrusters or fins, rotating clockwise
                CollidableObject.Rotation += rotationRate * (float)gameTime.ElapsedGameTime.TotalSeconds * Acceleration + 0.005f;
            }
        }

        /// <summary>
        ///     Draw Player
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw player
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, _colliding ? Color.Red : Color.White, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);

            if (_isMainThrusterActive)
            {
                // Draw main thruster particle
                //_mainThrusterParticle.Draw(spriteBatch);
            }
        }
    }
}