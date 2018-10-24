using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    internal class Enemy
    {
        // TODO: refine documentation and more

        /// <summary>
        /// CollidableObject for this Enemy; contains rotation, position, collision etc.
        /// </summary>
        public CollidableObject CollidableObject;

        /// <summary>
        /// Standard spawning position
        /// </summary>
        private Vector2 _spawnPosition;

        // TODO: targeting AI
        /// <summary>
        ///     Position in world
        /// </summary>
        public Vector2 InWorldPosition;

        /// <summary>
        /// Texture used when Enemy is alive
        /// </summary>
        private readonly Texture2D _aliveTexture2D;

        /// <summary>
        /// Texture used when Enemy is dead
        /// </summary>
        private readonly Texture2D _deadTexture2D;

        public bool IsEnemyDead;

        /// <summary>
        ///     Creates a new instance of Enemy with a texture, CollidableObject and type
        /// </summary>
        /// <param name="aliveTexture2D">Texture for enemy when alive</param>
        /// <param name="deadTexture2D">Texture for enemy when dead</param>
        /// <param name="spawnPosition">The spawn position of the object</param>
        public Enemy(Texture2D aliveTexture2D, Texture2D deadTexture2D, Vector2 spawnPosition)
        {

            InWorldPosition = spawnPosition;
            _aliveTexture2D = aliveTexture2D;
            _deadTexture2D = deadTexture2D;
            // Create a new CollidableObject with alive texture and spawn
            CollidableObject = new CollidableObject(aliveTexture2D, spawnPosition);
            // Logging statement
            // Console.WriteLine("Created a new enemy with position of " + CollidableObject.Position);
        }

        public void Explode()
        {
            // Reset rotation
            CollidableObject.Rotation = 0.0f;
            // Change texture
            CollidableObject.LoadTexture(_deadTexture2D);
        }

        /// <summary>
        /// Reset Enemy, ie. position, texture etc.
        /// </summary>
        public void Reset()
        {
            // Change texture
            CollidableObject.LoadTexture(_aliveTexture2D);
        }

        /// <summary>
        /// Updates position of enemy relative to the background
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Moves object relative to player by subtracting upper-left coordinate of the background to the object´s position in world
            CollidableObject.Position.X = InWorldPosition.X - InGame.MovableBackground.SourceRectangle.Location.X;
            CollidableObject.Position.Y = InWorldPosition.Y - InGame.MovableBackground.SourceRectangle.Location.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw Enemy
            spriteBatch.Draw(CollidableObject.Texture, CollidableObject.Position, null, Color.White, CollidableObject.Rotation, CollidableObject.Origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}