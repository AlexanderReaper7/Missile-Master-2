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

        private bool isEnterDown;
        /// <summary>
        /// Dictionary of menukeys to check
        /// </summary>
        public Dictionary<MenuKey, bool> menuKeysDown = new Dictionary<MenuKey, bool>();
        /// <summary>
        /// returns selected
        /// </summary>
        public Vector2 Selected
        {
            get { return selected; }
        }

        public bool IsEnterDown
        {

            get { return isEnterDown; }
            set { isEnterDown = value; }

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

        public Vector2 Update()
        {
            foreach (var item in menuKeysDown)
            {
                menuKeysDown[item.Key] = (item.Key.Update());

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.W)) || menuKeysDown[item.Key].Equals(new MenuKey(Keys.Up)))
                {
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                }

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.A)) || menuKeysDown[item.Key].Equals(new MenuKey(Keys.Left)))
                {
                    if (selected.X > 0)
                    {
                        selected.X--;
                    }
                }

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.S)) || menuKeysDown[item.Key].Equals(new MenuKey(Keys.Down)))
                {
                    if (selected.Y < selectionMax.Y)
                    {
                        selected.Y++;
                    }
                }

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.D)) || menuKeysDown[item.Key].Equals(new MenuKey(Keys.Right)))
                {
                    if (selected.X < selectionMax.X)
                    {
                        selected.X++;
                    }
                }

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.Enter)))
                {
                    isEnterDown = true;
                    selected = Vector2.Zero; // Reset selected
                }

                if (menuKeysDown[item.Key].Equals(new MenuKey(Keys.Escape)))
                {
                    selected = Vector2.Zero; // Reset selected
                }

                menuKeysDown[item.Key] = false;
            }
            return selected;
        }
    }
}
