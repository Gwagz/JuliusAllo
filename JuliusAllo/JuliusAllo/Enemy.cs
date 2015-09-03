using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuliusAllo
{
    class Enemy : Entity
    {
        private enum AITypes 
        { 
            None,     // Basic collisions and direction
            Basic     // Fallows PlayerShip
        };
        private AITypes AI = AITypes.Basic;

        private Vector2 _direction = Vector2.One;

        public Enemy()
        {
            image = Art.BaseEnemy;
            Position = new Vector2((float)Helper.Random.Next(0, (int)GameRoot.ScreenSize.X), (float)Helper.Random.Next(0, (int)GameRoot.ScreenSize.Y));
            ImageScale = 0.1f;
            Velocity = new Vector2(3f, 3f);
        }

        public override void Update()
        {
            //Move();

            Position.X += _direction.X * Velocity.X;

            CheckWindowCollisions();
            CheckEntityCollisions(true);

            Position.Y += _direction.Y * Velocity.Y;
            CheckWindowCollisions();
            CheckEntityCollisions(false);
        }

        // Verify collisions with game window
        private void CheckWindowCollisions()
        {
            if (BoundingBox.Left <= 0)
            {
                _direction.X = 1f;
            }

            if (BoundingBox.Right >= GameRoot.ScreenSize.X)
            {
                _direction.X = -1f;
            }

            if (BoundingBox.Top <= 0)
            {
                _direction.Y = 1;
            }

            if (BoundingBox.Bottom >= GameRoot.ScreenSize.Y)
            {
                _direction.Y = -1;
            }
        }

        private void CheckEntityCollisions(bool xAxis)
        {
            foreach (Entity e in EntityManager.EntitiesList)
            {
                if (e != this && BoundingBox.Intersects(e.BoundingBox))
                {
                    if (xAxis)
                    {
                        if (BoundingBox.Right >= e.BoundingBox.Left && _direction.X == 1)
                        {
                            _direction.X = -1;
                            //Position.X += _direction.X * Velocity.X;
                            break;
                        }
                        if (BoundingBox.Left <= e.BoundingBox.Right && _direction.X == -1)
                        {
                            _direction.X = 1;
                            //Position.X += _direction.X * Velocity.X;
                            break;
                        }
                    }
                    else
                    {
                        if (BoundingBox.Bottom >= e.BoundingBox.Top && _direction.Y == 1)
                        {
                            _direction.Y = -1;
                            //Position.Y += _direction.Y * Velocity.Y;
                            break;
                        }
                        if (BoundingBox.Top <= e.BoundingBox.Bottom && _direction.Y == -1)
                        {
                            _direction.Y = 1;
                            //Position.Y += _direction.Y * Velocity.Y;
                            break;
                        }
                    }
                }
            }
        }

        void Move()
        {
            
        }
    }
}
