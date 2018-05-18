using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Missile_Master_2
{
    internal static class EnemyManager
    {
        /// <summary>
        /// Types of enemies used in performing different types of logic
        /// </summary>
        public enum EnemyTypes
        {
            Missile,
            Building,

        }

        public static Enemy[] Enemies;

        private static Enemy _missileEnemy1 = new Enemy(InGame.Player.CollidableObject.Texture, new Vector2(600f), EnemyTypes.Missile);

        public static void AddEnemyToEnemies()
        {
            Enemies[0] = _missileEnemy1;
        }

        public static void CheckCollisionToPlayer()
        {
            foreach (Enemy enemy in Enemies)
            {
                enemy.CollidableObject.IsColliding(InGame.Player.CollidableObject);
            }
        }
    }
}
