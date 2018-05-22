using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    internal static class EnemyManager
    {
        /// <summary>
        /// List of all alive Enemies
        /// </summary>
        public static List<Enemy> Enemies = new List<Enemy>();

        public static void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public static void ClearEnemies()
        {
            Enemies.Clear();
        }

        public static bool CheckCollisionToPlayer()
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.CollidableObject.IsColliding(InGame.Player.CollidableObject))
                {
                    return true;
                }
            }

            return false;
        }

        public static void Update(GameTime gameTime)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Update(gameTime);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }
    }
}
