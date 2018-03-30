using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    class MenuKey
    {
        private bool isKeyUp;
        private Keys key;

        public MenuKey(Keys key)
        {
            this.key = key;
        }

    }
}
