using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    /// Controls key logic for use in menus
    /// </summary>
    class MenuKey
    {
        #region Fields

        /// <summary>
        /// Is selected key state up?
        /// </summary>
        private bool isKeyUp;

        /// <summary>
        /// Is selected key state down?
        /// </summary>
        private bool isKeyDown;

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

        public Keys Key { get { return key; } }

        public bool IsKeyDown { get { return isKeyDown; } }

        #endregion

        /// <summary>
        /// Creates a new instance of MenuKey with single key
        /// </summary>
        /// <param name="key">ID of key to use</param>
        public MenuKey(Keys key)
        {
            Console.WriteLine(key.ToString());
            this.key = key;
        }

        /// <summary>
        /// Update MenuKey logic
        /// </summary>
        /// <returns>Key is pressed</returns>
        public void Update()
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyUp(key))
            {
                isKeyUp = true;
            }

            if (keyboard.IsKeyDown(key) && isKeyUp)
            {
                isKeyUp = false;
                isKeyDown = true;
            }
            else
            {
                isKeyDown = false;
            }
        }

    }
}
