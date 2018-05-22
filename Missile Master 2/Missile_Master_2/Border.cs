using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    /// <summary>
    /// A Collidable box at the edge of the world
    /// </summary>
    internal class Border // TODO: Come up with a better name
    {
        /// <summary>
        /// CollidableObject for this Border; contains rotation, position, collision etc.
        /// </summary>
        public CollidableObject CollidableObject;

        /// <summary>
        ///     Position in world
        /// </summary>
        public Vector2 InWorldPosition;

        /// <summary>
        /// Initializes a new border with a texture and a destinationRectangle.
        /// </summary>
        /// <param name="texture">The texture associated with the object</param>
        /// <param name="destinationRectangle"></param> TODO: document me
        public Border(Texture2D texture, Rectangle destinationRectangle)
        {
            // Set InWorldPosition to the upper left coordinate of destinationRectangle
            InWorldPosition = new Vector2(destinationRectangle.X, destinationRectangle.Y);

            // Create a new CollidableObject with origin of 0
            CollidableObject = new CollidableObject(texture, InWorldPosition) {Origin = Vector2.Zero};
        }


        public void Update()
        {
            // Moves object relative to player by subtracting upper-left coordinate of background to object position in world
            CollidableObject.Position.X = InWorldPosition.X - InGame.MovableBackground.SourceRectangle.Location.X;
            CollidableObject.Position.Y = InWorldPosition.Y - InGame.MovableBackground.SourceRectangle.Location.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, Color.DarkRed, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
