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
        #region Fields

        /// <summary>
        /// Selected menu option
        /// </summary>
        private Vector2 selected;

        /// <summary>
        /// Number of menu options
        /// </summary>
        private Vector2 selectionMax;

        /// <summary>
        /// used in 
        /// </summary>
        private bool isEnterDown;
        private bool isEscapeDown;
        /// <summary>
        /// Array of MenuKey, every key is checked in Update() 
        /// </summary>
        MenuKey[] menuKeys = new MenuKey[] { new MenuKey(Keys.W), new MenuKey(Keys.A), new MenuKey(Keys.S), new MenuKey(Keys.D), new MenuKey(Keys.Up), new MenuKey(Keys.Left), new MenuKey(Keys.Down), new MenuKey(Keys.Right), new MenuKey(Keys.Enter), new MenuKey(Keys.Escape) };

        #endregion

        #region Properties 

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

        public bool IsEscapeDown
        {

            get { return isEscapeDown; }
            set { isEscapeDown = value; }

        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of MenuControlls
        /// </summary>
        /// <param name="selectionMax">Number of menu options</param>
        public MenuControlls(Vector2 selectionMax)
        {
            this.selectionMax = selectionMax;
        }

        #endregion

        public Vector2 Update()
        {
            foreach (var menukey in menuKeys)
            {
                menukey.Update();

                // Is W or UP arrow pressed
                if ((menukey.Key == Keys.W || menukey.Key == Keys.Up) && menukey.IsKeyDown)
                {
                    // And selected.Y is larger than 0, preventing it from becoming negative
                    if (selected.Y > 0)
                    {
                        // Subtract selected.Y by 1
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

                if (menukey.Key == Keys.Enter)
                {
                    if (menukey.IsKeyDown)
                    {
                        isEnterDown = true;
                    }
                    else
                    {
                        isEnterDown = false;
                    }
                }

                if (menukey.Key == Keys.Escape)
                {
                    if (menukey.IsKeyDown)
                    {
                        isEscapeDown = true;
                    }
                    else
                    {
                        isEscapeDown = false;
                    }
                }
            }
            return selected;
        }
    }
}
