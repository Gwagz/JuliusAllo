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
        private static PlayerShip instance;
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
            // ship logic goes here
        }
    }
}
