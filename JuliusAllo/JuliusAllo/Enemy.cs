using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuliusAllo
{
    class Enemy : Entity
    {
        Vector2 _direction = Vector2.One;
        public Enemy()
        {
            image = Art.BaseEnemy;
            Position = new Vector2((float)Helper.Random.Next(0, (int)GameRoot.ScreenSize.X), (float)Helper.Random.Next(0, (int)GameRoot.ScreenSize.Y));
            ImageScale = 0.1f;
            Velocity = new Vector2(3f, 3f);
        }

        public override void Update()
        {
            Move();
        }

        void Move()
        {
            // Verify collision with game window
            if (Position.X - Size.X / 2f <= 0)
            {
                _direction.X = 1f;
            }

            if (Position.X + Size.X / 2f >= GameRoot.ScreenSize.X)
            {
                _direction.X = -1f;
            }

            if (Position.Y - Size.Y / 2f <= 0)
            {
                _direction.Y = 1;
            }

            if (Position.Y + Size.Y / 2f >= GameRoot.ScreenSize.Y)
            {
                _direction.Y = -1;
            }

            Position += _direction * Velocity;
        }
    }
}
