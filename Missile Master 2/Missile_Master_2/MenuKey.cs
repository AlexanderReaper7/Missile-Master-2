using System;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    ///     An object used in MenuControls,
    ///     Prevents spam when pressing buttons in menus
    /// </summary>
    internal class MenuKey
    {
        /// <summary>
        ///     used when updating keyboard
        /// </summary>
        private KeyboardState _keyboard;

        /// <summary>
        ///     Creates a new instance of MenuKey with single key
        /// </summary>
        /// <param name="key">ID of key to use</param>
        public MenuKey(Keys key)
        {
            Console.WriteLine(key.ToString());
            Key = key;
        }

        /// <summary>
        ///     The Key ID for this MenuKey
        /// </summary>
        public Keys Key { get; }

        /// <summary>
        ///     The Boolean value representing if the set key was up during last check
        /// </summary>
        public bool WasKeyUp { get; private set; }

        /// <summary>
        ///     The Boolean value representing if the set key is currently pressed down
        /// </summary>
        public bool IsKeyDown { get; private set; }

        /// <summary>
        ///     Update MenuKey logic
        /// </summary>
        /// <returns>Key is pressed</returns>
        public void Update()
        {
            // Get current keyboard state 
            this._keyboard = Keyboard.GetState();

            // If key is up
            if (this._keyboard.IsKeyUp(Key))
            {
                // Then set wasKeyUp to true
                WasKeyUp = true;
            }

            // If key is up and was up before, preventing 
            if (this._keyboard.IsKeyDown(Key) && WasKeyUp)
            {
                // Then set wasKeyUp to false and isKeyDown to true,
                WasKeyUp = false;
                IsKeyDown = true;
            }
            else
            {
                // Else don't click
                IsKeyDown = false;
            }
        }
    }
}