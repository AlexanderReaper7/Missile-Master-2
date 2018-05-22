using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    // ReSharper disable once InconsistentNaming
    internal static class UI
    {
        /// <summary>
        ///     A single pixel used to draw solid colored objects
        /// </summary>
        private static Texture2D _pixel;

        /// <summary>
        /// Background for _fuelGauge to make it easier to see remaining fuel
        /// </summary>
        private static Rectangle _fuelGaugeBackground;
        /// <summary>
        /// Rectangle showing remaining fuel
        /// </summary>
        private static Rectangle _fuelGauge;

        public static void LoadContent(ContentManager content)
        {
            // Load the single white pixel texture
            _pixel = content.Load<Texture2D>(@"images/pixel");
            // Set _fuelGaugeBackground rectangle to be on top of screen with a 5px border
            _fuelGaugeBackground = new Rectangle(5, 5, Game1.ScreenBounds.X - 10, 30);
            // Set _fuelGauge
            _fuelGauge = new Rectangle(10, 10, _fuelGaugeBackground.Width - 10, _fuelGaugeBackground.Height - 10);
        }

        public static void Update()
        {
            // Check if fuel is 0 or negative
            if (InGame.Player.Fuel <= 0)
            {
                // Then set _fuelGauge width to 0, making it invisible.
                _fuelGauge.Width = 0;
            }
            else
            {
                // Else set _fuelGauge width to % remaining of total
                _fuelGauge.Width = (int)(_fuelGaugeBackground.Width * (InGame.Player.Fuel / Player.MaxFuel) - 10);
            }   
        }
        /// <summary>
        /// Draws all InGame UI elements
        /// </summary>
        /// <param name="spriteBatch"></param>
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_pixel, _fuelGaugeBackground, Color.WhiteSmoke);
            spriteBatch.Draw(_pixel, _fuelGauge, Color.Green);
            spriteBatch.DrawString(Game1.PixelArt32Normal, "Fuel:", new Vector2(_fuelGauge.X, _fuelGauge.Y), Color.Black, 0.0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0.0f);
        }
    }
}