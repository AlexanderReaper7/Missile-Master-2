using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    /// An object used in MenuControlls,
    /// Prevents spam when pressing buttons in menues
    /// </summary>
    class MenuKey
    {
        #region Fields

        /// <summary>
        /// was the selected key up during last check?
        /// </summary>
        private bool wasKeyUp;

        /// <summary>
        /// Is selected key down?
        /// </summary>
        private bool on;

        /// <summary>
        /// Key ID
        /// </summary>
        private Keys key;

        /// <summary>
        /// used when updating keyboard
        /// </summary>
        private KeyboardState keyboard;

        #endregion

        #region Properties

        /// <summary>
        /// The set key for this MenuKey
        /// </summary>
        public Keys Key
        {
            get { return key; }
        }

        /// <summary>
        /// The Boolean value representing if the set key was up during last check
        /// </summary>
        public bool WasKeyUp
        {
            get { return wasKeyUp; }
        }

        /// <summary>
        /// The Boolean value representing if the set key is currently pressed down
        /// </summary>
        public bool IsKeyDown
        {
            get { return on; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of MenuKey with single key
        /// </summary>
        /// <param name="key">ID of key to use</param>
        public MenuKey(Keys key)
        {
            Console.WriteLine(key.ToString());
            this.key = key;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Update MenuKey logic
        /// </summary>
        /// <returns>Key is pressed</returns>
        public void Update()
        {
            // Get current keyboard state 
            keyboard = Keyboard.GetState();

            // If key is up
            if (keyboard.IsKeyUp(key))
            {
                // Then set wasKeyUp to true
                wasKeyUp = true;
            }

            // If key is up and was up before, preventing 
            if (keyboard.IsKeyDown(key) && wasKeyUp)
            {
                // Then set wasKeyUp to false and isKeyDown to true,
                wasKeyUp = false;
                on = true;
            }
            else
            {
                // Else dont click
                on = false;
            }
        }

        #endregion

    }
}
