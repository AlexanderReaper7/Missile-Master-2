using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    class Menu
    {
        MenuControlls menuControlls;
        private string[] menuOptionsStr = new string[] { "campaign", "Level Select", "Exit" };
        private Vector2[] menuOptionsPos = {new Vector2()}
        private Vector2 selected;

        public void Update(GameTime gameTime)
        {
             selected = menuControlls.GetSelected(new Vector2(menuOptionsStr.Count(), 0));
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

        }
    }
}
