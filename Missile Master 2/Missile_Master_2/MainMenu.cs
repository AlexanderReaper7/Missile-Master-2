using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    /// Draws and does logic for gamestate mainMenu
    /// </summary>
    static class MainMenu
    {
        // TODO : Add custom font
        // private static SpriteFont pixelArt32Normal = Game1.pixelArt32Normal;

        /// <summary>
        /// String array of menu option names
        /// </summary>
        private static string[] menuOptionsStr = new string[] { "Campaign", "Level Select", "Exit" };

        /// <summary>
        /// Vector2 array of menu option positions
        /// </summary>
        private static Vector2[] menuOptionsPos = { new Vector2(Game1.screenBounds.X / 8, 20), new Vector2(Game1.screenBounds.X / 8, 60), new Vector2(Game1.screenBounds.X / 8, 100), };

        /// <summary>
        /// selected menu option
        /// </summary>
        private static Vector2 selected;

        /// <summary>
        /// MainMenu background image
        /// </summary>
        public static Texture2D background;

        /// <summary>
        /// Controlls keyboard actions in menus
        /// </summary>
        private static MenuControlls menuControll = new MenuControlls(new Vector2(0, menuOptionsStr.Count() - 1));

        public static void LoadContent(ContentManager content)
        {
            background = content.Load<Texture2D>(@"images/MainMenuBG");
        }

        /// <summary>
        /// Updates MainMenu gamestate logic
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            selected = menuControll.Update(); // Updates selected menu option
            // Change gamestate to the selected one on ENTER
            if (menuControll.IsEnterDown)
            {
                switch ((int)selected.Y)
                {
                    // Campaign
                    case 0: 
                        Console.WriteLine("Entering Campaign");
                        Game1.gameState = Game1.Gamestates.Campaign;
                        break;

                    // Level select
                    case 1:
                        Console.WriteLine("Entering LevelSelect");
                        Game1.gameState = Game1.Gamestates.LevelSelect;
                        break;
                    
                    // Exit
                    case 2:
                        Game1.gameState = Game1.Gamestates.Exit;
                        break;
                }
            }
        }

        /// <summary>
        /// Draws the MainMenu gamestate
        /// </summary>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw background in whole window
            spriteBatch.Draw(background, new Rectangle(0, 0, (int)Game1.screenBounds.X, (int)Game1.screenBounds.Y), Color.White);
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
    }
}
