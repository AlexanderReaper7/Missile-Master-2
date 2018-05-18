using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    /// <summary>
    ///     Draws and does logic for gamestate mainMenu
    /// </summary>
    internal static class MainMenu
    {
        // TODO : Add custom font
        // private static SpriteFont pixelArt32Normal = Game1.pixelArt32Normal;

        /// <summary>
        ///     String array of menu option names
        /// </summary>
        private static readonly string[] MenuOptionsStr = {"Campaign", "Level Select", "Exit"};

        /// <summary>
        ///     Vector2 array of menu option positions
        /// </summary>
        private static readonly Vector2[] MenuOptionsPos = {new Vector2(Game1.ScreenBounds.X / 8, 20), new Vector2(Game1.ScreenBounds.X / 8, 60), new Vector2(Game1.ScreenBounds.X / 8, 100)};

        /// <summary>
        ///     selected menu option
        /// </summary>
        private static Vector2 _selected;

        /// <summary>
        ///     MainMenu background image
        /// </summary>
        public static Texture2D Background;

        /// <summary>
        ///     Controlls keyboard actions in menus
        /// </summary>
        private static readonly MenuControls MenuControl = new MenuControls(new Vector2(0, MenuOptionsStr.Count() - 1));

        public static void LoadContent(ContentManager content)
        {
            Background = content.Load<Texture2D>(@"images/MainMenuBG");
        }

        /// <summary>
        ///     Updates MainMenu gamestate logic
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            _selected = MenuControl.Update(); // Updates selected menu option

            // If enter is pressed
            if (MenuControl.IsEnterDown)
            {
                // then switch gamestate
                switch ((int) _selected.Y)
                {
                    // Campaign
                    case 0:
                        Console.WriteLine("Entering Campaign");
                        Game1.GameState = Game1.Gamestates.Campaign;
                        break;

                    // Level select
                    case 1:
                        Console.WriteLine("Entering LevelSelect");
                        Game1.GameState = Game1.Gamestates.LevelSelect;
                        break;

                    // Exit
                    case 2:
                        Game1.GameState = Game1.Gamestates.Exit;
                        break;
                }
            }
        }

        /// <summary>
        ///     Draws the MainMenu gamestate
        /// </summary>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings.</param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw background in whole window
            spriteBatch.Draw(Background, new Rectangle(0, 0, (int) Game1.ScreenBounds.X, (int) Game1.ScreenBounds.Y), Color.White);

            // Iterate through every entry in menuOptionsStr arrray
            for (int i = 0; i < MenuOptionsStr.Length; i++)
            {
                // If selected menu option is int i
                spriteBatch.DrawString(_selected.Y == i ? Game1.PixelArt32Bold : Game1.PixelArt32Normal, MenuOptionsStr[i], MenuOptionsPos[i], Color.Black);
            }
        }
    }
}