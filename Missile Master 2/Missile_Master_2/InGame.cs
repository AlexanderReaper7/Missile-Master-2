using System;
using System.Diagnostics;
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
            // Tutorial
            Level1, 
            // First real level
            Level2 
        }

        public static Player Player = new Player(); //TODO: Make Player static

        /// <summary>
        /// Currently active level
        /// </summary>
        private static Levels CurrentLevel = Levels.Level1;

        /// <summary>
        /// Array of borders
        /// </summary>
        public static Border[] Borders;


        #region Textures

        private static Texture2D _smallExplosionTexture2D;
        private static Texture2D _enemyMissileTexture2D;
        private static Texture2D _ground1Texture2D;
        // ReSharper disable once InconsistentNaming
        private static Texture2D _transparent1pxTexture2D;

        #endregion

        public static void LoadContent(ContentManager content)
        {
            // Load UI
            UI.LoadContent(content);
            // Load player
            Player.LoadContent(content);
            //Load Textures
            _smallExplosionTexture2D = content.Load<Texture2D>(@"images/SmallExplosion1");
            _enemyMissileTexture2D = content.Load<Texture2D>(@"images/V-2"); // TODO: Make a custom enemy missile texture
            _ground1Texture2D = content.Load<Texture2D>(@"images/GroundY+");
            _transparent1pxTexture2D = content.Load<Texture2D>(@"images/Transparent1px");
            // Load Level 1
            Level1Content(content);
            // Load Borders TODO: Make a border manager class to handle collision
            Borders = new Border[]
            {
                // Top
                new Border(_transparent1pxTexture2D, new Rectangle(0, 0, MovableBackground.Texture.Width, 20)),
                // Left
                new Border(_transparent1pxTexture2D, new Rectangle(0, 0, 20, MovableBackground.Texture.Height)),
                // Right
                new Border(_transparent1pxTexture2D, new Rectangle(MovableBackground.Texture.Width, 0, -20, MovableBackground.Texture.Height))

            };
        }

    /// <summary>
    /// Moves the background by moving the source rectangle of the MovableBackground
    /// </summary>
    /// <param name="velocity">Vector2 to move background by</param>
    public static void MoveBackground(Vector2 velocity)
        {
            // Add velocity to the total of velocity
            Vector2 velocityTotal = velocity;

            // Update point to the new velocityTotal 
            Point point = new Point((int)velocityTotal.X, (int)velocityTotal.Y);

            // Remove whole numbers from velocityTotal, leaving only the residue for to be added during the next tick.
            velocityTotal.X -= (int)velocityTotal.X;
            velocityTotal.Y -= (int)velocityTotal.Y;

            // Move Background only by whole numbers (int)
            MovableBackground.MoveBackground(point);
        }


        #region Logging

        // TODO: remove Logging when done
        private static double _loggingTimer;
        private static void Log(GameTime gameTime)
        {
            _loggingTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (!(_loggingTimer > 250))
            {
                return;
            }
            _loggingTimer = 0;

            //Console.WriteLine("rot " + Player.CollidableObject.Rotation);
            //Console.WriteLine("acc " + Player.Acceleration);
            //Console.WriteLine("pos " + Player.CollidableObject.Position);
            //Console.WriteLine("Sou " + MovableBackground.SourceRectangle);
            //Console.WriteLine("MaxX " + MovableBackground.IsSourceMaxX);
            //Console.WriteLine("MaxY " + MovableBackground.IsSourceMaxY);
            //Console.WriteLine("MinX " + MovableBackground.IsSourceMinX);
            //Console.WriteLine("MinY " + MovableBackground.IsSourceMinY);
            //Console.WriteLine("Fuel " + Player.Fuel);

            //Console.WriteLine("----   END   ----");
        }

        #endregion

        /// <summary>
        ///  Current MovableBackground
        /// </summary>
        public static MovableBackground MovableBackground
        {
            get
            {
                switch (CurrentLevel)
                {
                    case Levels.Level1:
                        return _movableBackground1;
                    case Levels.Level2:
                        return _movableBackground2;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                switch (CurrentLevel)
                {
                    case Levels.Level1:
                        _movableBackground1 = value;
                        break;
                    case Levels.Level2:
                        _movableBackground2 = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Updates all InGame objects
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public static void Update(GameTime gameTime)
        {
            // Update objects 
            _movableBackground1.Update();
            Player.Update(gameTime);
            EnemyManager.Update(gameTime);
            UI.Update();
            // Log
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

        private static MovableBackground _movableBackground1;

        /// <summary>
        ///     Load level 1 content, is called whenever entering Level 1 for the first time.
        /// </summary>
        private static void Level1Content(ContentManager content)
        {
            _movableBackground1 = new MovableBackground(content.Load<Texture2D>(@"images/Level1BG"), new Rectangle(0, 4096 - Game1.ScreenBounds.Y, Game1.ScreenBounds.X, Game1.ScreenBounds.Y));
            // Missile enemy 1 (no AI)
            EnemyManager.AddEnemy(new Enemy(_enemyMissileTexture2D, _smallExplosionTexture2D, new Vector2(700f, 3900)));
            // Ground TODO: Make Ground into a border
            EnemyManager.AddEnemy(new Enemy(_ground1Texture2D, _ground1Texture2D, new Vector2(_movableBackground1.Texture.Width / 2, _movableBackground1.Texture.Height - 7))); 
        }

        private static void Level1Draw(SpriteBatch spriteBatch)
        {
            _movableBackground1.Draw(spriteBatch);
        }

        #endregion

        #region Level 2
        // TODO: Make Level 2
        private static MovableBackground _movableBackground2;

        #endregion
    }
}