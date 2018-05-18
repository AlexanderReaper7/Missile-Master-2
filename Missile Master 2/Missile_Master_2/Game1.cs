using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    /// <summary>
    ///     This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        /// <summary>
        ///     List of states for the game
        /// </summary>
        public enum Gamestates
        {
            MainMenu,
            Campaign,
            InGame,
            LevelSelect,
            Exit
        }

        /// <summary>
        ///     Bounds of game window
        /// </summary>
        public static Point ScreenBounds = new Point(1280, 720);

        /// <summary>
        ///     Normal style pixel-art SpriteFont in size 32pt
        /// </summary>
        public static SpriteFont PixelArt32Normal;

        /// <summary>
        ///     Bold style pixel-art SpriteFont in size 32pt
        /// </summary>
        public static SpriteFont PixelArt32Bold;

        /// <summary>
        ///     Current GameState
        /// </summary>
        public static Gamestates GameState = Gamestates.MainMenu; // TODO : Move GameState to separate class called GameState

        // TODO : Enemy manager
        // TODO : Collision 
        // TODO : Particles
        // TODO : Local World Location
        // TODO : Uniform style

        /// <summary>
        ///     Main GraphicsDeviceManager
        /// </summary>
        private readonly GraphicsDeviceManager _graphics;

        /// <summary>
        ///     Main spriteBatch
        /// </summary>
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic related content.
        ///     Calling base.Initialize will enumerate through any components and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Set window size to screenBounds
            _graphics.PreferredBackBufferWidth = ScreenBounds.X;
            _graphics.PreferredBackBufferHeight = ScreenBounds.Y;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            MainMenu.LoadContent(Content);
            InGame.LoadContent(Content, GraphicsDevice);

            PixelArt32Normal = Content.Load<SpriteFont>(@"Font/PixelArt32Normal");
            PixelArt32Bold = Content.Load<SpriteFont>(@"Font/PixelArt32Bold");
        }

        /// <summary>
        ///     UnloadContent will be called once per game and is the place to unload
        ///     all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            // Back or End exits the game
            if (gamepad.Buttons.Back == ButtonState.Pressed || keyboard.IsKeyDown(Keys.End))
            {
                Exit();
            }

            switch (GameState)
            {
                case Gamestates.MainMenu:
                    MainMenu.Update(gameTime);
                    break;

                case Gamestates.Campaign:
                    Campaign.Update(gameTime);
                    break;

                case Gamestates.InGame:
                    InGame.Update(gameTime);
                    break;

                case Gamestates.LevelSelect:
                    LevelSelect.Update(gameTime);
                    break;

                case Gamestates.Exit:
                    Exit();
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear previous drawings, replacing it with a white background
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            switch (GameState)
            {
                case Gamestates.MainMenu:
                    MainMenu.Draw(_spriteBatch);
                    break;

                case Gamestates.Campaign:
                    Campaign.Draw(_spriteBatch);
                    break;

                case Gamestates.InGame:
                    InGame.Draw(_spriteBatch);
                    break;

                case Gamestates.LevelSelect:
                    LevelSelect.Draw(_spriteBatch);
                    break;

                case Gamestates.Exit:
                    Exit();
                    break;
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}