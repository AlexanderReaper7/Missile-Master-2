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
    /// Draws and does logic for gamestate mainMenu
    /// </summary>
    static class MainMenu
    {
        // private static SpriteFont pixelArt32Normal = Game1.pixelArt32Normal;

        /// <summary>
        /// String array of menu option names
        /// </summary>
        private static string[] menuOptionsStr = new string[] { "campaign", "Level Select", "Exit" };

        /// <summary>
        /// Vector2 array of menu option positions
        /// </summary>
        private static Vector2[] menuOptionsPos = { new Vector2(Game1.screenBounds.X / 8, 20), new Vector2(Game1.screenBounds.X / 8, 60), new Vector2(Game1.screenBounds.X / 8, 100), };

        /// <summary>
        /// selected menu option
        /// </summary>
        private static Vector2 selected;

        /// <summary>
        /// Controlls keyboard actions in menus
        /// </summary>
        private static MenuControlls menuControll = new MenuControlls(new Vector2(0, menuOptionsStr.Count() - 1));

        static bool enterPrevDown;

        ///// <summary>
        ///// Updates MainMenu gamestate logic
        ///// </summary>
        ///// <param name="gameTime"></param>
        //public static void Update(GameTime gameTime)
        //{
        //    selected = menuControll.GetSelected(); // Updates selected
        //    // Change gamestate to the selected one on ENTER
        //    if (menuControll.IsKeyDown(Keys.Enter) && !enterPrevDown)
        //    {
        //        Console.WriteLine("ENTER");
        //        enterPrevDown = true;
        //        switch ((int)selected.Y)
        //        {
        //            case 0:
        //                Game1.gameState = Game1.Gamestates.Campaign;
        //                break;

        //            case 1:
        //                Game1.gameState = Game1.Gamestates.LevelSelect;
        //                break;

        //            case 2:
        //                Game1.gameState = Game1.Gamestates.Exit;
        //                break;
        //        }
        //    }
        //}

        /// <summary>
        /// Draws the MainMenu gamestate
        /// </summary>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.mainMenuBG, new Rectangle(0, 0, (int)Game1.screenBounds.X, (int)Game1.screenBounds.Y), Color.White); // Background

            for (int i = 0; i < menuOptionsStr.Count(); i++)
            {
                if (selected.Y == i)
                {
                    spriteBatch.DrawString(Game1.pixelArt32Bold, menuOptionsStr[i], menuOptionsPos[i], Color.Black); // Selected menu option (Bold)
                }
                else
                {
                    spriteBatch.DrawString(Game1.pixelArt32Normal, menuOptionsStr[i], menuOptionsPos[i], Color.Black); // Not selected menu option (Normal)
                }
            }
        }
    }
}
