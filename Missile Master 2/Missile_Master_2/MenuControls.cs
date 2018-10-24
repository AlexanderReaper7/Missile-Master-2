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
        ///     Number of menu options
        /// </summary>
        private readonly Vector2 _selectionMax;

        /// <summary>
        ///     Selected menu option
        /// </summary>
        private Vector2 _selected;

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
            // Update Menukey
            MenuKey.Update();

                // When W or UP arrow keys are pressed
                if (( MenuKey.SingleActivationKey(Keys.W)  || MenuKey.SingleActivationKey(Keys.Up) ))
                {
                    // And selected.Y is GREATER THAN 0, preventing it from becoming negative,
                    if (this._selected.Y > 0)
                    {
                        // then subtract selected.Y by 1
                        this._selected.Y--;
                    }
                }

            // When A or Left arrow keys are pressed
            if ((MenuKey.SingleActivationKey(Keys.A) || MenuKey.SingleActivationKey(Keys.Left)))
                {
                    // And selected.X is GREATER THAN 0, preventing it from becoming negative
                    if (this._selected.X > 0)
                    {
                        // Then subtract selected.X by 1
                        this._selected.X--;
                    }
                }

            // When S or Down arrow keys are pressed
            if ((MenuKey.SingleActivationKey(Keys.S) || MenuKey.SingleActivationKey(Keys.Down)))
                {
                    // And selected.Y is LESS THAN selectionMax.Y, preventing it from exceeding maximum Y selection range,
                    if (this._selected.Y < this._selectionMax.Y)
                    {
                        // Then add selected.Y by 1
                        this._selected.Y++;
                    }
                }

            // When D or Right arrow keys are pressed
            if ((MenuKey.SingleActivationKey(Keys.D) || MenuKey.SingleActivationKey(Keys.Right)))
                {
                    // And selected.X is LESS THAN selectionMax.X, preventing it from exceeding maximum X selection range, 
                    if (this._selected.X < this._selectionMax.X)
                    {
                        // Then add selected.X by 1
                        this._selected.X++;
                    }

                // if Enter is pressed
                    if (MenuKey.SingleActivationKey(Keys.Enter))
                    {
                        IsEnterDown = true;
                    }
                    else
                    {
                        IsEnterDown = false;
                    }

                // If Escape pressed
                    if (MenuKey.SingleActivationKey(Keys.Escape))
                    {
                        IsEscapeDown = true;
                    }
                    else
                    {
                        IsEscapeDown = false;
                    }

            }

            // Return updated selected
            return this._selected;
        }
    }
}