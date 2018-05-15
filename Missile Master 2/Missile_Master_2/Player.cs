using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    internal class Player
    {
        private double _timer;


        /// <summary>
        ///     Called upon to load player textures etc.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="graphics"></param>
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            this.Texture = content.Load<Texture2D>(@"images/V-2");
            this._graphics = graphics;

            this.Origin = new Vector2(this.Texture.Width / 2, this.Texture.Height / 2);

            this._collidableObject = new CollidableObject(this.Texture, new Vector2(100, 200), 0.0f);

            // Logging statement
            Console.WriteLine("Player Loaded");
        }

        public void Update(GameTime gameTime)
        {
            // Get new direction
            this.Direction = new Vector2((float) Math.Cos(this._collidableObject.Rotation), (float) Math.Sin(this._collidableObject.Rotation));

            this._timer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (this._timer > 250)
            {
                this._timer = 0;

                Console.WriteLine("direction" + this.Direction);
                Console.WriteLine("rotation" + this._collidableObject.Rotation);
                Console.WriteLine("acceleration" + this.Acceleration);
                Console.WriteLine("position" + this._collidableObject.Position);
            }

            // Run Player Controlls
            Controlls();
            this.Velocity += this.Direction * this.Acceleration * (float) gameTime.ElapsedGameTime.TotalSeconds;

            // Update position
            this._collidableObject.Position += this.Velocity;

            // Slowdown
            this.Acceleration *= 0.90f;
            this.Velocity *= 0.9f;

            if (this.Acceleration < 0.2)
            {
                this.Acceleration = 0;
            }
        }


        /// <summary>
        ///     keyboard controlls for ingame
        /// </summary>
        private void Controlls()
        {
            // Get keyboard
            this._keyboard = Keyboard.GetState();

            if (this._keyboard.IsKeyDown(Keys.W) || this._keyboard.IsKeyDown(Keys.Up))
            {
                this.Acceleration++;

                // TODO : Add fuel usage
            }

            if (this._keyboard.IsKeyDown(Keys.A) || this._keyboard.IsKeyDown(Keys.Left))
            {
                this._collidableObject.Rotation -= this.rotationRate;
            }

            if (this._keyboard.IsKeyDown(Keys.S) || this._keyboard.IsKeyDown(Keys.Down))
            {
                // Brake
                this.Acceleration *= 0.6f;
            }

            if (this._keyboard.IsKeyDown(Keys.D) || this._keyboard.IsKeyDown(Keys.Right))
            {
                this._collidableObject.Rotation += this.rotationRate;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this._collidableObject.Position, null, Color.White, this._collidableObject.Rotation, this.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }

        #region Fields

        private GraphicsDevice _graphics;
        public Texture2D Texture;
        public Vector2 Velocity; // TODO : Make air-resistance and more fluid movement
        public float Acceleration;
        public Vector2 Origin;
        public Vector2 Direction;

        /// <summary>
        ///     Rotation of player in radians
        /// </summary>
        private readonly float rotationRate = MathHelper.Pi / 128f; // TODO : Add upgrade levels to rotationRate

        private KeyboardState _keyboard;

        private CollidableObject _collidableObject;

        #endregion
    }
}