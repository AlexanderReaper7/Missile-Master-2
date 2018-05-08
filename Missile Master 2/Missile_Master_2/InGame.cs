using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Missile_Master_2
{
    static class InGame
    {
        #region Fields

        static public Player player = new Player();
        static MenuKey esc = new MenuKey(Keys.Escape);
        #endregion

        #region Static Methods

        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            // Load player
            player.LoadContent(content, graphics);
        }

        public static void Update(GameTime gameTime)
        {
            // Update Escape key
            esc.Update();
            // If Esc is down
            if (esc.IsKeyDown)
            {
                // Then go to MainMenu
                Game1.gameState = Game1.Gamestates.MainMenu; // TODO : Add Pause menu
            }

            // Update player
            player.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw player
            player.Draw(spriteBatch);
        }

        #endregion
    }
}
