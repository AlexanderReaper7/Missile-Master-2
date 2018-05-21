using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    internal class Enemy
    {
        public CollidableObject CollidableObject;
         // TODO: AI
        /// <summary>
        ///     Use this to move object
        /// </summary>
        public Vector2 InWorldPosition;

        /// <summary>
        ///     Creates a new instance of Enemy with a texture, CollidableObject and type
        /// </summary>
        /// <param name="texture">The texture associated with the object</param>
        /// <param name="position">The spawn position of the object</param>
        public Enemy(Texture2D texture, Vector2 position)
        {
            this.InWorldPosition = position;
            CollidableObject = new CollidableObject(texture, position);

            Console.WriteLine("Created new enemy with position of " + CollidableObject.Position);
        }

        public void Update(GameTime gameTime)
        {
            // Moves object relative to player by subtracting upper-left coordinate of background to object position in world
            CollidableObject.Position.X = InWorldPosition.X - InGame.MovableBackground1.SourceRectangle.Location.X;
            CollidableObject.Position.Y = InWorldPosition.Y - InGame.MovableBackground1.SourceRectangle.Location.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, Color.White, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}