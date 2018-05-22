using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    /// <summary>
    ///     Draws and does logic for Campaign gamestate
    /// </summary>
    internal static class Campaign
    {
        /// <summary>
        ///     String array of menu option names
        /// </summary>
        private static readonly string[] MenuOptionsStr = {"Continue", "New Campaign", "Back"};

        /// <summary>
        ///     Vector2 array of menu option positions
        /// </summary>
        private static readonly Vector2[] MenuOptionsPos = {new Vector2(Game1.ScreenBounds.X / 8, 20), new Vector2(Game1.ScreenBounds.X / 8, 60), new Vector2(Game1.ScreenBounds.X / 8, 100)};

        private static Vector2 _selected;
        private static readonly MenuControls MenuControl = new MenuControls(new Vector2(0, MenuOptionsStr.Length - 1));

        public static void Update(GameTime gameTime)
        {
            _selected = MenuControl.Update(); // Update selected

            // TODO: Add campaign
            // If enter is not pressed
            if (!MenuControl.IsEnterDown)
            {
                // Then return
                return;
            }
            // Else (enter is pressed) 
            switch ((int) _selected.Y)
            {
                case 0: // Continue
                    Game1.GameState = Game1.GameStates.InGame;
                    break;

                case 1: // New Campaign
                    Game1.GameState = Game1.GameStates.InGame;
                    break;

                case 2: // Back
                    Game1.GameState = Game1.GameStates.MainMenu;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     Draw Campaign menu
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw background in whole window
            spriteBatch.Draw(MainMenu.Background, new Rectangle(0, 0, (int) Game1.ScreenBounds.X, (int) Game1.ScreenBounds.Y), Color.White);

            // Iterate through every entry in menuOptionsStr arrray
            for (int i = 0; i < MenuOptionsStr.Count(); i++)
            {
                // If selected menu option is int i
                spriteBatch.DrawString(_selected.Y == i ? Game1.PixelArt32Bold : Game1.PixelArt32Normal, MenuOptionsStr[i], MenuOptionsPos[i], Color.Black);
            }
        }
    }
}