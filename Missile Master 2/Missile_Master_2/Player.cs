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
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;
        Vector2 direction;
        /// <summary>
        /// Rotation of player in radians
        /// </summary>
        float angle;
        public Color[] textureData;

        #endregion



        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            texture = content.Load<Texture2D>(@"images/V-2");
            this.graphics = graphics;

            textureData = new Color[texture.Width * texture.Height];
            texture.GetData(textureData);
        }

        public void Update(GameTime gameTime)
        {
            direction = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            origin = new Vector2(rectangle.Width / 2, rectangle.Height / 2);


            position += direction * velocity;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height),null,Color.White,angle,origin,SpriteEffects.None,1f);
        }
    }
}
