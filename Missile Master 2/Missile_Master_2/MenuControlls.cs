using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Missile_Master_2
{
    /// <summary>
    /// Controlls keyboard logic in menus
    /// </summary>
    class MenuControlls
    {
        /// <summary>
        /// Selected menu option
        /// </summary>
        private Vector2 selected;
        /// <summary>
        /// Number of menu options
        /// </summary>
        private Vector2 selectionMax;

        /// <summary>
        /// Dictionary of menukeys to check
        /// </summary>
        public Dictionary<MenuKey, bool> menuKeysDown = new Dictionary<MenuKey, bool>();

        public Vector2 Selected
        {
            get { return selected; }
        }

        /// <summary>
        /// Creates a new instance of MenuControlls
        /// </summary>
        /// <param name="selectionMax">Number of menu options</param>
        public MenuControlls(Vector2 selectionMax)
        {
            this.selectionMax = selectionMax;

            menuKeysDown.Add(new MenuKey(Keys.W), false);
            menuKeysDown.Add(new MenuKey(Keys.A), false);
            menuKeysDown.Add(new MenuKey(Keys.S), false);
            menuKeysDown.Add(new MenuKey(Keys.D), false);
            menuKeysDown.Add(new MenuKey(Keys.Up), false);
            menuKeysDown.Add(new MenuKey(Keys.Left), false);
            menuKeysDown.Add(new MenuKey(Keys.Down), false);
            menuKeysDown.Add(new MenuKey(Keys.Right), false);
            menuKeysDown.Add(new MenuKey(Keys.Enter), false);
            menuKeysDown.Add(new MenuKey(Keys.Escape), false);

        }

        public void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<MenuKey, bool> item in menuKeysDown)
            {
                menuKeysDown[item.Key] = (item.Key.Update());
            }

            if(menuKeysDown[])
        }
    }
}
