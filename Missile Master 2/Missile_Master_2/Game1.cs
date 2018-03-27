using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Missile_Master_2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Menu menu;
        MenuControlls menuControlls;

        public static Vector2 screenBounds = new Vector2(1280, 720);

        // GameStates
        public enum Gamestates
        {
            Menu,
            Campaign,
            LevelSelect,
            Exit
        }

        public static Gamestates gameState = Gamestates.Menu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)screenBounds.X;
            graphics.PreferredBackBufferHeight = (int)screenBounds.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void UnloadContent() {}

        protected override void Update(GameTime gameTime)
        {
            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            // Back or End exits the game
            if (gamepad.Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.End))
            {
                this.Exit();
            }

            switch(gameState)
            {
                case Gamestates.Menu:
                    menu.Update(gameTime);
                    break;

                case Gamestates.Campaign:
                    
                    break;

                case Gamestates.LevelSelect:

                    break;

                case Gamestates.Exit:
                    this.Exit();
                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            switch (gameState)
            {
                case Gamestates.Menu:
                    menu.Draw(spriteBatch);
                    break;

                case Gamestates.Campaign:

                    break;

                case Gamestates.LevelSelect:

                    break;

                case Gamestates.Exit:
                    this.Exit();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
