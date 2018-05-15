using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    internal class MovableBackground
    {
        private Rectangle _destinationRectangle;
        private Rectangle _sourceRectangle;
        private Texture2D _texture;

        public MovableBackground(Texture2D texture, Rectangle destinationRectangle, Rectangle sourceRectangle)
        {
            this._texture = texture;
            this._destinationRectangle = destinationRectangle;
            this._sourceRectangle = sourceRectangle;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Background
            spriteBatch.Draw(this._texture,this._destinationRectangle, this._sourceRectangle, Color.White);
        }
    }
}