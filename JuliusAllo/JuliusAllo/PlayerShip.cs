using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuliusAllo
{
    /// <summary>
    /// This is the ship that the Player controls.
    /// </summary>
    class PlayerShip : Entity
    {
        private enum MovementMode
        {
            HONRIZONTAL,
            TRIDIMENSION
        };


        private static PlayerShip instance;
        private static MovementMode movementMode = MovementMode.HONRIZONTAL;
        public static PlayerShip Instance
        {
            get
            {
                if (instance == null)
                    instance = new PlayerShip();

                return instance;
            }
        }

        private PlayerShip()
        {
            image = Art.Player;
            Position = GameRoot.ScreenSize / 2;
            Radius = 10;
        }

        public override void Update()
        {
            Orientation += Input.GetRotation();

            if (Input.GetMovementDirection() != 0)
            {
                const float speed = 8;

                Vector2 movement = new Vector2();
                movement.X = (float) Math.Sin(System.Convert.ToDouble(Orientation));
                movement.Y = (float) Math.Cos(System.Convert.ToDouble(Orientation));
                movement.Y *= -1;
                
                // Mouvement arriere
                if (Input.GetMovementDirection() == -1)
                {
                    movement *= -1;
                }

                Velocity = speed * movement;
                Position += Velocity;
                Position = Vector2.Clamp(Position, Size / 2, GameRoot.ScreenSize - Size / 2);
            }
        }
    }
}
