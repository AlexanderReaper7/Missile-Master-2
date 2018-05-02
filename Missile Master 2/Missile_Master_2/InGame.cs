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
        #region Fields

        static Player player = new Player();

        #endregion

        public static void Load(ContentManager content, GraphicsDevice graphics)
        {
            // Load player
            player.LoadContent(content, graphics);
        }

        public static void Update()
        {

            // Update player
            player.Update();
        }

        public static void Draw(SpriteBatch spritebatch)
        {
            // Draw player
            player.Draw(spritebatch);
        }

    }
}
