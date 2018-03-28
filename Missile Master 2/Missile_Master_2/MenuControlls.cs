using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Missile_Master_2
{
    class MenuControlls
    {
        private KeyboardState keyboard = Keyboard.GetState();

        public Vector2 GetSelected(Vector2 selectedMax)
        {
            bool keysAreUp = true;
            Vector2 selected = Vector2.Zero;

            // Detect if keys are up
            if (Keyboard.GetState().IsKeyUp(Keys.S) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.W) && Keyboard.GetState().IsKeyUp(Keys.Up))
            {
                keysAreUp = true;
            }

            if (keysAreUp)
            {
                if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
                {
                    Console.WriteLine('W');
                    keysAreUp = false;
                    if (selected.Y < selectedMax.Y)
                    {
                        selected.Y++;
                    }
                }

                if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                {
                    Console.WriteLine('S');
                    keysAreUp = false;
                    if (selected.Y > 0)
                    {
                        selected.Y--;
                    }
                }

                if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                {
                    Console.WriteLine('D');
                    keysAreUp = false;
                    if (selected.X < selectedMax.X)
                    {
                        selected.X++;
                    }
                }

                if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                {
                    Console.WriteLine('A');
                    keysAreUp = false;
                    if (selected.X > 0)
                    {
                        selected.X--;
                    }
                }
            }

            return selected;
        }

        public bool IsEnterPressed()
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                Console.WriteLine("Enter");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEscPressed()
        {
            if (keyboard.IsKeyDown(Keys.Escape))
            {
                Console.WriteLine("ESC");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
