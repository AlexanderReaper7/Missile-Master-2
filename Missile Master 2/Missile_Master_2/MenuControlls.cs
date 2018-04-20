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

        MenuKey[] menuKeys;
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
                if (menukey.Key == Keys.W || menukey.Key == Keys.Up && menukey.IsKeyDown)
                {
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                }

                if (menukey.Key.Key == Keys.A || menukey.Key.Key == Keys.Up && menukey.Value)
                {
                    if (selected.X > selectionMax.X)
                    {
                        selected.X--;
                    }
                }

                if (menukey.Key.Key == Keys.S || menukey.Key.Key == Keys.Down && menukey.Value)
                {
                    if (selected.Y < selectionMax.Y)
                    {
                        selected.Y++;
                    }
                }

                if (menukey.Key.Key == Keys.D || menukey.Key.Key == Keys.Right && menukey.Value)
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
