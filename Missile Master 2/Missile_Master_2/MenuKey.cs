using System;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    ///     An object used in MenuControlls,
    ///     Prevents spam when pressing buttons in menues
    /// </summary>
    internal class MenuKey
    {
        #region Constructors

        /// <summary>
        ///     Creates a new instance of MenuKey with single key
        /// </summary>
        /// <param name="key">ID of key to use</param>
        public MenuKey(Keys key)
        {
            Console.WriteLine(key.ToString());
            this.Key = key;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        ///     Update MenuKey logic
        /// </summary>
        /// <returns>Key is pressed</returns>
        public void Update()
        {
            // Get current keyboard state 
            this.keyboard = Keyboard.GetState();

            // If key is up
            if (this.keyboard.IsKeyUp(this.Key))
            {
                // Then set wasKeyUp to true
                this.WasKeyUp = true;
            }

            // If key is up and was up before, preventing 
            if (this.keyboard.IsKeyDown(this.Key) && this.WasKeyUp)
            {
                // Then set wasKeyUp to false and isKeyDown to true,
                this.WasKeyUp = false;
                this.IsKeyDown = true;
            }
            else
            {
                // Else dont click
                this.IsKeyDown = false;
            }
        }

        #endregion

        #region Fields

        /// <summary>
        ///     used when updating keyboard
        /// </summary>
        private KeyboardState keyboard;

        #endregion

        #region Properties

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

        #endregion
    }
}