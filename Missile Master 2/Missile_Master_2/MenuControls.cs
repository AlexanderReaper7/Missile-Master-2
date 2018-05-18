using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    ///     An object used for easy control in menus using the keyboard
    /// </summary>
    internal class MenuControls
    {
        /// <summary>
        ///     Array of MenuKey, every key is checked in Update()
        /// </summary>
        private readonly MenuKey[] _menuKeys = {new MenuKey(Keys.W), new MenuKey(Keys.A), new MenuKey(Keys.S), new MenuKey(Keys.D), new MenuKey(Keys.Up), new MenuKey(Keys.Left), new MenuKey(Keys.Down), new MenuKey(Keys.Right), new MenuKey(Keys.Enter), new MenuKey(Keys.Escape)};

        /// <summary>
        ///     Number of menu options
        /// </summary>
        private readonly Vector2 _selectionMax;

        /// <summary>
        ///     Selected menu option
        /// </summary>
        private Vector2 _selected;

        // TODO : Move gamestate changing to here
        // TODO : Make MenuControls static  

        /// <summary>
        ///     Creates a new instance of MenuControls
        /// </summary>
        /// <param name="selectionMax">Number of menu options</param>
        public MenuControls(Vector2 selectionMax)
        {
            this._selectionMax = selectionMax;
        }


        /// <summary>
        ///     returns selected
        /// </summary>
        public Vector2 Selected => this._selected;

        public bool IsEnterDown { get; private set; }

        public bool IsEscapeDown { get; set; }

        /// <summary>
        ///     Updates selected menu option in menus
        /// </summary>
        /// <returns>New Vector2 position</returns>
        public Vector2 Update()
        {
            // For every MenuKey in the menuKeys array
            foreach (MenuKey menukey in this._menuKeys)
            {
                // Update the current MenuKey in menuKeys array
                menukey.Update();

                // TODO : Change these if statements to a switch

                // When W or UP arrow keys are pressed
                if (( menukey.Key == Keys.W || menukey.Key == Keys.Up ) && menukey.IsKeyDown)
                {
                    // And selected.Y is GREATER THAN 0, preventing it from becoming negative,
                    if (this._selected.Y > 0)
                    {
                        // then subtract selected.Y by 1
                        this._selected.Y--;
                    }
                }

                // When A or Left arrow keys are pressed
                if (( menukey.Key == Keys.A || menukey.Key == Keys.Left ) && menukey.IsKeyDown)
                {
                    // And selected.X is GREATER THAN 0, preventing it from becoming negative
                    if (this._selected.X > 0)
                    {
                        // Then subtract selected.X by 1
                        this._selected.X--;
                    }
                }

                // When S or Down arrow keys are pressed
                if (( menukey.Key == Keys.S || menukey.Key == Keys.Down ) && menukey.IsKeyDown)
                {
                    // And selected.Y is LESS THAN selectionMax.Y, preventing it from exceeding maximum Y selection range,
                    if (this._selected.Y < this._selectionMax.Y)
                    {
                        // Then add selected.Y by 1
                        this._selected.Y++;
                    }
                }

                // When D or Right arrow keys are pressed
                if (( menukey.Key == Keys.D || menukey.Key == Keys.Right ) && menukey.IsKeyDown)
                {
                    // And selected.X is LESS THAN selectionMax.X, preventing it from exceeding maximum X selection range, 
                    if (this._selected.X < this._selectionMax.X)
                    {
                        // Then add selected.X by 1
                        this._selected.X++;
                    }
                }

                // Switch is used non-duplicated keys
                switch (menukey.Key)
                {
                    // If current menukey is Enter
                    case Keys.Enter:

                        // And it is pressed
                        IsEnterDown = menukey.IsKeyDown;

                        break;

                    // If current menukey is Escape
                    case Keys.Escape:

                        // And it is pressed
                        IsEscapeDown = menukey.IsKeyDown;

                        break;
                }
            }

            // Return updated selected
            return this._selected;
        }
    }
}