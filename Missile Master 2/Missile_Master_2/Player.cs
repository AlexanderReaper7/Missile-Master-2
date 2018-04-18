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
        private GraphicsDevice graphics;

        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;

        Vector2 direction;
        float angle;

        public Color[] textureData;

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
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height),null,Color.White,playerAngle,playerOrigin,SpriteEffects.None,1f);
        }

        private bool collision(Rectangle object1, Color[] data1, Rectangle object2, Color[] data2)
        {

            var RotatedP0 = new Vector2.Transform(new Vector2(object2.Top, object2.Left), Matrix.CreateRotationZ(angle));
            var RotatedP1 = new Vector2.Transform(new Vector2(object2.Bottom, object2.Right), Matrix.CreateRotationZ(angle));


            if (object1.Bottom < RotatedP0.Y)
                return perPixel(object1, data1, object2, data2);
            if (object1.Top > RotatedP1.Y)
                return perPixel(object1, data1, object2, data2);
            if (object1.Left > RotatedP1.X)
                return perPixel(object1, data1, object2, data2);
            if (object1.Right < RotatedP0.X)
                return perPixel(object1, data1, object2, data2);

            return true;
        }

        private bool perPixel(Rectangle object1, Color[] data1, Rectangle object2, Color[] data2)
        {
            //Bounds of collision
            int top = Math.Max(object1.Top, object2.Top);
            int bottom = Math.Min(object1.Bottom, object2.Bottom);
            int left = Math.Max(object1.Left, object2.Left);
            int right = Math.Min(object1.Right, object2.Right);

            //Check every pixel
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {

                    Color colourA = data1[(x - object1.Left) + (y - object1.Top) * object1.Width];

                    Vector2 v = Vector2.Transform(new Vector2(x, y), Matrix.CreateRotationZ(theta));

                    Color colourB = data2[(int)v.X, (int)v.Y];

                    if (colourA.A != 0 && colourB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
