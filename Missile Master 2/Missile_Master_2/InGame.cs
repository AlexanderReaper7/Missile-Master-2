using System;
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

        public static readonly Player Player = new Player();

        private static Levels CurrentLevel = Levels.Level1;

        private static Vector2 _velocityTotal;

        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            // Load player
            Player.LoadContent(content, graphics);

            // Load Level 1
            Level1Content(content, graphics);
        }

        public static void MoveBackground(Vector2 velocity)
        {
            _velocityTotal += velocity;

            Point point = new Point((int)velocity.X, (int)velocity.Y);

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
                Console.WriteLine("col " + );

                Console.WriteLine("----   END   ----");
            }
        }

        public static void Update(GameTime gameTime)
        {
            // Update player
            Player.Update(gameTime);

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

            EnemyManager.AddEnemyToEnemies();
        }

        private static void Level1Update(GameTime gameTime)
        {
            EnemyManager.CheckCollisionToPlayer();
        }

        private static void Level1Draw(SpriteBatch spriteBatch)
        {
            MovableBackground1.Draw(spriteBatch);
        }

        #endregion
    }
}