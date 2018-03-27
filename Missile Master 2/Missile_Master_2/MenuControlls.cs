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
                    keysAreUp = false;
                    if (selected.X < selectedMax.X)
                    {
                        selected.X++;
                    }
                }

                if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                {
                    keysAreUp = false;
                    if (selected.X > 0)
                    {
                        selected.X--;
                    }
                }

                if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                {
                    keysAreUp = false;
                    if (selected.Y < selectedMax.Y)
                    {
                        selected.Y++;
                    }
                }

                if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                {
                    keysAreUp = false;
                    if (selected.X > 0)
                    {
                        selected.Y--;
                    }
                }
            }

            return selected;
        }

        public bool IsEnterPressed()
        {
            if (keyboard.IsKeyDown(Keys.Enter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
