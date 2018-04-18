using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Missile_Master_2
{
    static class InGame
    {


        static Player player = new Player();

        public static void Load(ContentManager content, GraphicsDevice graphics)
        {
            player.LoadContent(content, graphics);
        }

        public static void Update()
        {

        }

        public static void Draw(SpriteBatch spritebatch)
        {
            player.Draw(spritebatch);
        }

        //public static bool IntersectsPixel(Rectangle rect1, Color[] data1, Rectangle rect2, Color data2)
        //{
        //    // Collision bounds
        //    int top = Math.Max(rect1.Top, rect2.Top);
        //    int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
        //    int left = Math.Max(rect1.Left, rect2.Left);
        //    int right = Math.Min(rect1.Right, rect2.Right);


        //    // For every pixel
        //    for (int y = top; y < bottom; y++)
        //    {
        //        for (int x = left; x < right; x++)
        //        {
        //            Color color1 = data1[(x - rect1.Left) + (y - rect1.Top) * rect1.Width];
        //            Color color2 = data2[(x - rect2.Left) + (y - rect2.Top) * rect2.Width];

        //            if (color1.A != 0 && color2.A != 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}
