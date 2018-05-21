using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    /// <summary>
    /// A non-collidable object, e.g. particles
    /// </summary>
    internal class Particle
    {
        // TODO: document me
        /// <summary>
        /// The texture associated with the object
        /// </summary>
        public Texture2D Texture;
        public Rectangle DestinationRectangle;
        public Rectangle SourceRectangle;
        public Vector2 Origin;
        /// <summary>
        /// Rotation of texture in radians
        /// </summary>
        public float Rotation;
        /// <summary>
        /// Time in milliseconds between frames
        /// </summary>
        public double MaxFrameTime;
        /// <summary>
        /// Time in milliseconds currently spent on current frame
        /// </summary>
        private double _currentFrameTime;
        /// <summary>
        /// Number of the frame currently being drawn
        /// </summary>
        public int Frame;

        public Particle(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle, Vector2 origin, float rotation, double maxFrameTime)
        {
            Texture = texture;
            DestinationRectangle = destinationRectangle;
            SourceRectangle = sourceRectangle;
            Origin = origin;
            Rotation = rotation;
            MaxFrameTime = maxFrameTime;
        }

        public void Animate(GameTime gameTime)
        {
            SourceRectangle.X = SourceRectangle.Width * Frame % Texture.Width;
            _currentFrameTime += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_currentFrameTime >= MaxFrameTime)
            {
                // Reset _currentFrameTime
                _currentFrameTime = 0;
                // Move to next frame
                Frame++;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White, Rotation, Origin, SpriteEffects.None, 0.0f);
        }
    }
}
