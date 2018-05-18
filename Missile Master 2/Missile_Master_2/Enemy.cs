using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Missile_Master_2
{
    class Enemy
    {
        public CollidableObject CollidableObject;
        public EnemyManager.EnemyTypes EnemyType;

        /// <summary>
        /// Creates a new instance of Enemy with a texture, CollidableObject and type
        /// </summary>
        /// <param name="texture">The texture associated with the object</param>
        /// <param name="position">The spawn position of the object</param>
        /// <param name="enemyType">The type of enemy</param>
        public Enemy(Texture2D texture, Vector2 position, EnemyManager.EnemyTypes enemyType)
        {
            this.CollidableObject = new CollidableObject(texture, position);
            this.EnemyType = enemyType;

            Console.WriteLine("Created new enemy of type " + enemyType + " and position of " + CollidableObject.Position);
        }
    }
}
