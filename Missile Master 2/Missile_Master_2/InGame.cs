using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Missile_Master_2
{
    internal static class InGame
    {
        #region Fields

        private static Player _player = new Player();
        private static readonly MenuKey esc = new MenuKey(Keys.Escape); // TODO : remove me when I become redundant
        private static MovableBackground _movableBackground;
        #endregion

        #region Static Methods

        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            // Load player
            _player.LoadContent(content, graphics);
            // _movableBackground = new MovableBackground(); TODO : Add Level Texture
        }

        public static void Update(GameTime gameTime)
        {
            // Update Escape key
            esc.Update();

            // If Esc is down
            if (esc.IsKeyDown)
            {
                // Then go to MainMenu
                Game1.gameState = Game1.Gamestates.MainMenu; // TODO : Add Pause menu
            }

            // Update player
            _player.Update(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            // Draw player
            _player.Draw(spriteBatch);
        }

        #endregion
    }
}