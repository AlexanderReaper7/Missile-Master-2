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

        private static Rectangle _fuelGaugeBackground;
        private static Rectangle _fuelGauge;

        public static void LoadContent(ContentManager content)
        {
            _pixel = content.Load<Texture2D>(@"images/pixel");
            _fuelGaugeBackground = new Rectangle(5, 5, Game1.ScreenBounds.X - 10, 30);
            _fuelGauge = new Rectangle(10, 10, _fuelGaugeBackground.Width - 10, _fuelGaugeBackground.Height - 10);
        }

        public static void Update()
        {
            // Check if fuel is 0 or negative
            if (InGame.Player.Fuel <= 0)
            {
                _fuelGauge.Width = 0;
            }
            else
            {
                // Else set 
                _fuelGauge.Width = (int)(_fuelGaugeBackground.Width * (InGame.Player.Fuel / InGame.Player.MaxFuel) - 10);
            }   
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_pixel, _fuelGaugeBackground, Color.WhiteSmoke);
            spriteBatch.Draw(_pixel, _fuelGauge, Color.Green);
        }
    }
}