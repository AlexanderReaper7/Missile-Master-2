﻿using System;
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
        private Tuple<Keys, bool> valuePair;

        /// <summary>
        /// Is selected key state up?
        /// </summary>
        private bool isKeyUp;
        /// <summary>
        /// Key ID
        /// </summary>
        //private Keys key;
        /// <summary>
        /// used when updating keyboard
        /// </summary>
        private KeyboardState keyboard;

        public MenuKey(Keys key)
        {
            Console.WriteLine("Added MenuKey " + key.ToString());

            valuePair = new Tuple<Keys, bool>(key, false);
        }


        /// <summary>
        /// Creates a new instance of MenuKey with single key
        /// </summary>
        /// <param name="key">ID of key to use</param>


        /// <summary>
        /// Update MenuKey logic
        /// </summary>
        /// <returns>Key is pressed</returns>
        public bool Update()
        {
            keyboard = Keyboard.GetState();
            if (keyboard.IsKeyUp(key))
            {
                isKeyUp = true;
            }

            if (keyboard.IsKeyDown(key) && isKeyUp)
            {
                isKeyUp = false;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
