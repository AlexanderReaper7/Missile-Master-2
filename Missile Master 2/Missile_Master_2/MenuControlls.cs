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
        KeyboardState keyboard;
        private Vector2 selected;
        private Vector2 selectionMax;
        private bool keysAreUp;

        /// <summary>
        /// Make sure to '- 1' when using number of menu options menuOptionsStr.Count()
        /// </summary>
        /// <param name="selectionMax">Number of menu options</param>
        public MenuControlls(Vector2 selectionMax)
        {
            this.selectionMax = selectionMax;
        }

        /// <summary>
        /// Checks if selected key is down and returns it as an boolean value
        /// </summary>
        /// <param name="key">Name of key to check</param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            keyboard = Keyboard.GetState(); // Update keyboard

            if (keyboard.IsKeyDown(key)) // Check key
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if selected key is up and returns it as an boolean value
        /// </summary>
        /// <param name="key">Name of key to check</param>
        /// <returns></returns>
        public bool IsKeyUp(Keys key)
        {
            keyboard = Keyboard.GetState(); // Update keyboard

            if (keyboard.IsKeyUp(key)) // Check key
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MenuKey(Keys key)
        {
            isKeyUp
            keyboard = Keyboard.GetState(); // Update keyboard

            if (keyboard.IsKeyDown(key)) // Check key
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a Vector2 efter performing keyboard logic
        /// </summary>
        /// <returns>Selected item</returns>
        public Vector2 GetSelected()
        {
            keyboard = Keyboard.GetState(); // Update keyboard
            // Reset selected
            if (keyboard.IsKeyDown(Keys.R)) 
            {
                selected = Vector2.Zero;
            }

            // Detect if menu keys (W A S D UP DOWN LEFT RIGTH) are up
            if (keyboard.IsKeyUp(Keys.S) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.W) && keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.A) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.D) && keyboard.IsKeyUp(Keys.Right))
            {
                keysAreUp = true;
            }

            if (keysAreUp)
            {
                // W & Up, Y--
                if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
                {
                    Console.WriteLine('W');
                    keysAreUp = false;
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                    return selected;
                }

                // S & Down, Y++
                if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                {
                    Console.WriteLine('S');
                    keysAreUp = false;
                    if (selected.Y < selectionMax.Y)
                    {
                        selected.Y++;
                    }
                    return selected;
                }

                // D & Right, X++
                if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                {
                    Console.WriteLine('D');
                    keysAreUp = false;
                    if (selected.X < selectionMax.X)
                    {
                        selected.X++;
                    }
                    return selected;
                }

                // A & Left, X--
                if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                {
                    Console.WriteLine('A');
                    keysAreUp = false;
                    if (selected.X > 0)
                    {
                        selected.X--;
                    }
                    return selected;
                }
            }

            Console.WriteLine(selected);
            return selected; // Finish
        }
    }
}
