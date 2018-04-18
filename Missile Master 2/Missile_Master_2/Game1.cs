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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        /// <summary>
        /// Main GraphicsDeviceManager
        /// </summary>
        GraphicsDeviceManager graphics;

        /// <summary>
        /// Main spriteBatch
        /// </summary>
        SpriteBatch spriteBatch;

        /// <summary>
        /// Size of game window
        /// </summary>
        public static Vector2 screenBounds = new Vector2(1280, 720);

        /// <summary>
        /// Normal pixel-art sprite font in size 32pt
        /// </summary>
        public static SpriteFont pixelArt32Normal;

        /// <summary>
        /// Bold pixel-art spritefont in size 32pt
        /// </summary>
        public static SpriteFont pixelArt32Bold;
        /// <summary>
        /// Menu background
        /// </summary>
        public static Texture2D mainMenuBG;
        /// <summary>
        /// Sprite sheet for non background textures
        /// </summary>
        public static Texture2D SpriteSheet;

        /// <summary>
        /// List of states for the game
        /// </summary>
        public enum Gamestates
        {
            MainMenu,
            Campaign,
            Ingame,
            LevelSelect,
            Exit
        }

        public static Gamestates gameState = Gamestates.Ingame;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)screenBounds.X;
            graphics.PreferredBackBufferHeight = (int)screenBounds.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            pixelArt32Normal = Content.Load<SpriteFont>(@"Font/PixelArt32Normal");
            pixelArt32Bold = Content.Load<SpriteFont>(@"Font/PixelArt32Bold");

            SpriteSheet = Content.Load<Texture2D>(@"images/SpriteSheet");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            // Back or End exits the game
            if (gamepad.Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.End))
            {
                this.Exit();
            }

            switch (gameState)
            {
                case Gamestates.MainMenu:
                    MainMenu.Update(gameTime);
                    break;

                case Gamestates.Campaign:
                    Campaign.Update(gameTime);
                    break;

                case Gamestates.Ingame:
                    InGame.Update();
                    break;

                case Gamestates.LevelSelect:

                    break;

                case Gamestates.Exit:
                    this.Exit();
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            switch (gameState)
            {
                case Gamestates.MainMenu:
                    MainMenu.Draw(spriteBatch);
                    break;

                case Gamestates.Campaign:
                    Campaign.Draw(spriteBatch);
                    break;

                case Gamestates.LevelSelect:

                    break;

                case Gamestates.Exit:
                    this.Exit();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
