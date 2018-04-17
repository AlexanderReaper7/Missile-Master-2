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
                item.Value = item.Key.Update;

                if( item.Key.Key == Keys.W || item.Key.Key == Keys.Up && item.Value)
                {
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                }
                if (item.Key.Key == Keys.A || item.Key.Key == Keys.Up && item.Value)
                {
                    if (selected.X > selectionMax.X)
                    {
                        selected.X--;
                    }
                }
                if (item.Key.Key == Keys.S || item.Key.Key == Keys.Down && item.Value)
                {
                    if (selected.Y < selectionMax.Y)
                    {
                        selected.Y++;
                    }
                }
                if (item.Key.Key == Keys.D || item.Key.Key == Keys.Right && item.Value)
                {
                    if (selected.X < 0)
                    {
                        selected.X++;
                    }
                }
            }
            return selected;
        }
    }
}
