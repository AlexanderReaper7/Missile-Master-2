using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    internal static class InGame
    {
        private enum Levels
        {
            Level1,
            Level2
        }

        public static Player Player = new Player();

        private static Levels CurrentLevel = Levels.Level1;

        private static Vector2 _velocityTotal;

        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            UI.LoadContent(content);
            // Load player
            Player.LoadContent(content);

            // Load Level 1
            Level1Content(content, graphics);
        }

        public static void MoveBackground(Vector2 velocity)
        {
            _velocityTotal += velocity;

            Point point = new Point((int)_velocityTotal.X, (int)_velocityTotal.Y);

            _velocityTotal.X -= (int)_velocityTotal.X;
            _velocityTotal.Y -= (int)_velocityTotal.Y;

            switch (CurrentLevel)
            {
                case Levels.Level1:
                    MovableBackground1.MoveBackground(point);
                    break;
                case Levels.Level2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        private static void Log(GameTime gameTime)
        {
            _loggingTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_loggingTimer > 250)
            {
                _loggingTimer = 0;

                Console.WriteLine("vel " + _velocityTotal);
                Console.WriteLine("dir " + Player.Direction);
                Console.WriteLine("rot " + Player.CollidableObject.Rotation);
                Console.WriteLine("acc " + Player.Acceleration);
                Console.WriteLine("pos " + Player.CollidableObject.Position);
                Console.WriteLine("Sou " + MovableBackground1.SourceRectangle);
                Console.WriteLine("MaxX " + MovableBackground1.IsSourceMaxX);
                Console.WriteLine("MaxY " + MovableBackground1.IsSourceMaxY);
                Console.WriteLine("MinX " + MovableBackground1.IsSourceMinX);
                Console.WriteLine("MinY " + MovableBackground1.IsSourceMinY);
                Console.WriteLine("Fuel " + Player.Fuel);

                Console.WriteLine("----   END   ----");
            }
        }

        public static void Update(GameTime gameTime)
        {
            MovableBackground1.Update();
            // Update player
            Player.Update(gameTime);
            EnemyManager.Update(gameTime);
            UI.Update();
            switch (CurrentLevel)
            {
                case Levels.Level1:
                    Level1Update(gameTime);
                    break;
                case Levels.Level2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Log(gameTime);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            switch (CurrentLevel)
            {
                case Levels.Level1:
                    Level1Draw(spriteBatch);
                    break;
                case Levels.Level2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Draw player
            Player.Draw(spriteBatch);
            // Draw Enemies
            EnemyManager.Draw(spriteBatch);
            // Draw UI
            UI.Draw(spriteBatch);
        }

        #region Level 1

        public static MovableBackground MovableBackground1;
        private static double _loggingTimer;

        /// <summary>
        ///     Load level 1 content, is called whenever entering Level 1 for the first time.
        /// </summary>
        private static void Level1Content(ContentManager content, GraphicsDevice graphics)
        {
            MovableBackground1 = new MovableBackground(content.Load<Texture2D>(@"images/Level1Background"));

            EnemyManager.AddEnemy(new Enemy(Player.CollidableObject.Texture, new Vector2(600f)));

            EnemyManager.AddEnemy(new Enemy(content.Load<Texture2D>(@"images/GroundY+"), new Vector2(MovableBackground1.Texture.Width / 2, MovableBackground1.Texture.Height - 7))); // TODO: create relative ratios
        }

        private static void Level1Update(GameTime gameTime)
        {
        }

        private static void Level1Draw(SpriteBatch spriteBatch)
        {
            MovableBackground1.Draw(spriteBatch);
        }

        #endregion
    }
}