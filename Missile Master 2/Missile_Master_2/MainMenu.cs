using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    class MainMenu
    {
        private MenuControlls menuControlls;
        // private static SpriteFont pixelArt32Normal = Game1.pixelArt32Normal; // TODO : Fix menu controlls
        private static string[] menuOptionsStr = new string[] { "campaign", "Level Select", "Exit" };
        private Vector2[] menuOptionsPos = {new Vector2(Game1.screenBounds.X / 8, 20), new Vector2(Game1.screenBounds.X / 8, 60), new Vector2(Game1.screenBounds.X / 8, 100), };
        // private Vector2[] menuOptionsOrigin = { new Vector2(pixelArt32Normal.MeasureString(menuOptionsStr[0])) }; // TODO : Implement me?
        private Vector2 selected;

        public void Update(GameTime gameTime)
        {
             selected = menuControlls.GetSelected(new Vector2(menuOptionsStr.Count())); // Get selected
            // Change gamestate to the selected one
            if (menuControlls.IsEnterPressed())
            {
                switch ((int)selected.X)
                {
                    case 0:
                        Game1.gameState = Game1.Gamestates.Campaign;
                        break;

                    case 1:
                        Game1.gameState = Game1.Gamestates.LevelSelect;
                        break;

                    case 2:
                        Game1.gameState = Game1.Gamestates.Exit;
                        break;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Game1.mainMenuBG,new Rectangle(0, 0, (int)Game1.screenBounds.X, (int)Game1.screenBounds.Y), Color.White); // Background

            for (int i = 0; i < menuOptionsStr.Count(); i++)
            {
                if (selected.X == i)
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
