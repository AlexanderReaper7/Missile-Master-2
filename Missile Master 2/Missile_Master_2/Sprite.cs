using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    class Sprite
    {
        /// <summary>
        /// Sprite texture
        /// </summary>
        public Texture2D Texture;
        /// <summary>
        /// Texture width
        /// </summary>
        private int frameWidth;
        /// <summary>
        /// Texture Height
        /// </summary>
        private int frameHeight;
        /// <summary>
        /// Current framenumber
        /// </summary>
        private int currentFrame;
        /// <summary>
        /// Time between each frame in seconds
        /// </summary>
        private float frameTime = 2f;
        /// <summary>
        /// Time the current frame has existeed in seconds
        /// </summary>
        private float timeForCurrentFrame;
        /// <summary>
        /// Color used to tint sprite texture
        /// </summary>
        private Color tintColor = Color.White;
        /// <summary>
        /// Sprite rotation
        /// </summary>
        private float rotation;
        /// <summary>
        /// Circle hitbox radius
        /// </summary>
        public int collisionRadius;
        /// <summary>
        /// Not used
        /// </summary>
        public int boundingXPadding;
        /// <summary>
        /// Not used
        /// </summary>
        public int boundingYPadding;
        /// <summary>
        /// Sprite position onscreen
        /// </summary>
        protected Vector2 position;
        /// <summary>
        /// Sprite velocity
        /// </summary>
        protected Vector2 velocity;
        /// <summary>
        /// List of sprites frames
        /// </summary>
        protected List<Rectangle> frames = new List<Rectangle>();
        /// <summary>
        /// Creates a new instance of Sprite
        /// </summary>
        /// <param name="position">Position onscreen</param>
        /// <param name="texture">Sprite texture</param>
        /// <param name="initialFrame">Sprite position and size in spritesheet</param>
        /// <param name="velocity">Sprite velocity</param>
        public Sprite(Vector2 position, Texture2D texture, Rectangle initialFrame, Vector2 velocity)
        {
            this.position = position;
            Texture = texture;
            this.velocity = velocity;

            frames.Add(initialFrame);
            frameWidth = initialFrame.Width;
            frameHeight = initialFrame.Height;
        }

        #region Get/Set
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public Color TintColor
        {
            get { return tintColor; }
            set { tintColor = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value % MathHelper.TwoPi; }
        }

        public int Frame
        {
            get { return currentFrame; }
            set { currentFrame = (int)MathHelper.Clamp(value, 0, frames.Count - 1); }
        }

        public float FrameTime
        {
            get { return frameTime; }
            set { frameTime = MathHelper.Max(0, value); }
        }

        public Rectangle Source
        {
            get { return frames[currentFrame]; }
        }

        public Rectangle Destination
        {
            get { return new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight); }
        }
        /// <summary>
        /// Center of sprite
        /// </summary>
        public Vector2 Center
        {
            get { return position + new Vector2(frameWidth / 2, frameHeight / 2); }
        }

        public Rectangle BoundingBoxRect
        {
            get { return new Rectangle((int)position.X + boundingXPadding, (int)position.Y + boundingYPadding, frameWidth - (boundingXPadding * 2), frameHeight - (boundingYPadding * 2)); }
        }
        #endregion

        public bool IsBoxColliding(Rectangle OtherBox)
        {
            return BoundingBoxRect.Intersects(OtherBox);
        }

        public bool IsCircleColliding(Vector2 otherCenter, float otherRadius)
        {
            if (Vector2.Distance(Center, otherCenter) < (collisionRadius + otherRadius))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Adds a frame to sprite´s list of frames
        /// </summary>
        /// <param name="frameRectangle">frame position in spritesheet</param>
        public void AddFrame(Rectangle frameRectangle)
        {
            frames.Add(frameRectangle);
        }
        /// <summary>
        /// Updates logic for sprite
        /// </summary>
        /// <param name="gametime">Provides a snapshot of timing values</param>
        public virtual void Update(GameTime gametime)
        {
            float elapsed = (float)gametime.ElapsedGameTime.TotalSeconds;

            timeForCurrentFrame += elapsed;

            // Go to next frame
            if (timeForCurrentFrame >= FrameTime)
            {
                currentFrame = (currentFrame + 1) % (frames.Count);
                timeForCurrentFrame = 0.0f;
            }

            position += (velocity * elapsed); // update position
        }
        /// <summary>
        /// Draws the sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Center, Source, tintColor, rotation, new Vector2(frameWidth / 2, frameHeight / 2), 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
