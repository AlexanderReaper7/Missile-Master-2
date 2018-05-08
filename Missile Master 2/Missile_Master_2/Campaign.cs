using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    /// Draws and does logic for Campaign gamestate
    /// </summary>
    static class Campaign
    {
        #region Fields
        /// <summary>
        /// String array of menu option names
        /// </summary>
        private static string[] menuOptionsStr = new string[] { "Continue", "New Campaign", "Back" };
        /// <summary>
        /// Vector2 array of menu option positions
        /// </summary>
        private static Vector2[] menuOptionsPos = { new Vector2(Game1.screenBounds.X / 8, 20), new Vector2(Game1.screenBounds.X / 8, 60), new Vector2(Game1.screenBounds.X / 8, 100), };
        private static Vector2 selected;
        private static MenuControlls menuControll = new MenuControlls(new Vector2(0, menuOptionsStr.Count() - 1));
        #endregion

        #region Static Methods
        public static void Update(GameTime gameTime)
        {
            selected = menuControll.Update(); // Update selected

            // Change gamestate to the selected menu option upon ENTER
            if (menuControll.IsEnterDown)
            {
                switch ((int)selected.Y)
                {
                    case 0: // Continue
                        Game1.gameState = Game1.Gamestates.Ingame;
                        break;

                    case 1: // New Campaign

                        break;

                    case 2: // Back
                        Game1.gameState = Game1.Gamestates.MainMenu;
                        break;
                }
            }
        }

        /// <summary>
        /// Draw Campaign menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw background in whole window
            spriteBatch.Draw(MainMenu.background, new Rectangle(0, 0, (int)Game1.screenBounds.X, (int)Game1.screenBounds.Y), Color.White); 

            // Iterate through every entry in menuOptionsStr arrray
            for (int i = 0; i < menuOptionsStr.Count(); i++)
            {
                // If selected menu option is int i
                if (selected.Y == i)
                {
                    // Then draw menu string in bold
                    spriteBatch.DrawString(Game1.pixelArt32Bold, menuOptionsStr[i], menuOptionsPos[i], Color.Black);
                }
                else
                {
                    // Else draw menu string in regular
                    spriteBatch.DrawString(Game1.pixelArt32Normal, menuOptionsStr[i], menuOptionsPos[i], Color.Black);
                }
            }
        }

        #endregion
    }
}
