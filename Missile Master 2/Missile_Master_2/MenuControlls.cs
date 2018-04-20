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

        MenuKey[] menuKeys = new MenuKey[] (new MenuKey(Keys.W), new MenuKey(Keys.A), new MenuKey(Keys.S), new MenuKey(Keys.D), new MenuKey(Keys.Up), new MenuKey(Keys.Left), new MenuKey(Keys.Down), new MenuKey(Keys.Right), new MenuKey(Keys.Enter));
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
        }

        public Vector2 Update()
        {
            foreach (var menukey in menuKeys)
            {
                menukey.Update();

                if ((menukey.Key == Keys.W || menukey.Key == Keys.Up) && menukey.IsKeyDown)
                {
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                }

                if ((menukey.Key == Keys.A || menukey.Key == Keys.Left) && menukey.IsKeyDown)
                {
                    if (selected.X > selectionMax.X)
                    {
                        selected.X--;
                    }
                }

                if ((menukey.Key == Keys.S || menukey.Key == Keys.Down) && menukey.IsKeyDown)
                {
                    if (selected.Y < selectionMax.Y)
                    {
                        selected.Y++;
                    }
                }

                if ((menukey.Key == Keys.D || menukey.Key == Keys.Right) && menukey.IsKeyDown)
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
