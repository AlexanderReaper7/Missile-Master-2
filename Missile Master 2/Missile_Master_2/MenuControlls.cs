using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Missile_Master_2
{
    /// <summary>
    /// An object used for easy controll in menues using the keyboard
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns>New Vector2 position</returns>
        public Vector2 Update()
        {
            // For every MenuKey in the menuKeys array
            foreach (MenuKey menukey in menuKeys)
            {
                // Update the current MenuKey in menuKeys array
                menukey.Update();

                // When W or UP arrow keys are pressed
                if ((menukey.Key == Keys.W || menukey.Key == Keys.Up) && menukey.IsKeyDown)
                {
                    // And selected.Y is GREATER THAN 0, preventing it from becoming negative,
                    if (selected.Y > 0)
                    {
                        // then subtract selected.Y by 1
                        selected.Y--;
                    }
                }

                // When A or Left arrow keys are pressed
                if ((menukey.Key == Keys.A || menukey.Key == Keys.Left) && menukey.IsKeyDown)
                {
                    // And selected.X is GREATER THAN 0, preventing it from becoming negative
                    if (selected.X > 0)
                    {
                        // Then subtract selected.X by 1
                        selected.X--;
                    }
                }

                // When S or Down arrow keys are pressed
                if ((menukey.Key == Keys.S || menukey.Key == Keys.Down) && menukey.IsKeyDown)
                {
                    // And selected.Y is LESS THAN selectionMax.Y, preventing it from exceeding maximum Y selection range,
                    if (selected.Y < selectionMax.Y)
                    {
                        // Then add selected.Y by 1
                        selected.Y++;
                    }
                }

                // When D or Right arrow keys are pressed
                if ((menukey.Key == Keys.D || menukey.Key == Keys.Right) && menukey.IsKeyDown)
                {
                    // And selected.X is LESS THAN selectionMax.X, preventing it from exceeding maximum X selection range, 
                    if (selected.X < selectionMax.X)
                    {
                        // Then add selected.X by 1
                        selected.X++;
                    }
                }

                // If current menukey is Enter
                if (menukey.Key == Keys.Enter)
                {
                    // And it is pressed
                    if (menukey.IsKeyDown)
                    {
                        // Then set isEnterDown to true
                        isEnterDown = true;
                    }
                    else
                    {
                        // Else set isEnterDown to false
                        isEnterDown = false;
                    }
                }

                // If current menukey is Escape
                if (menukey.Key == Keys.Escape)
                {
                    // And it is pressed
                    if (menukey.IsKeyDown)
                    {
                        // Then set isEscapeDown to true
                        isEscapeDown = true;
                    }
                    else
                    {
                        // Else set isEnterDown to false
                        isEscapeDown = false;
                    }
                }
            }
            // Return updated selected
            return selected;
        }
    }
}
