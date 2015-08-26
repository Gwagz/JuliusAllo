using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JuliusAllo
{

    static class Input
    {
        private static KeyboardState keyboardState, lastKeyboardState;
        private static MouseState mouseState, lastMouseState;


        public static Vector2 MousePosition { get { return new Vector2(mouseState.X, mouseState.Y); } }

        public static void Update()
        {
            lastKeyboardState = keyboardState;
            lastMouseState = mouseState;
          
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }

        // Checks if a key was just pressed down
        public static bool WasKeyPressed(Keys key)
        {
            return lastKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key);
        }

        public static int GetMovementDirection()
        {
            int direction = 0;

            if (keyboardState.IsKeyDown(Keys.W))
                direction = 1;
            if (keyboardState.IsKeyDown(Keys.S))
                direction = -1;
            
            return direction;
        }

        public static Vector2 GetHoriztontalMovementDirection()
        {
            Vector2 direction = new Vector2();
 
            if (keyboardState.IsKeyDown(Keys.A))
                direction.X -= 1;
            if (keyboardState.IsKeyDown(Keys.D))
                direction.X += 1;
            if (keyboardState.IsKeyDown(Keys.W))
                direction.Y -= 1;
            if (keyboardState.IsKeyDown(Keys.S))
                direction.Y += 1;
 
            // Clamp the length of the vector to a maximum of 1.
            if (direction.LengthSquared() > 1)
                direction.Normalize();
 
            return direction; 
        }

        public static float GetRotation()
        {
            float rotation = 0;
            if (keyboardState.IsKeyDown(Keys.A))
            {
                rotation -= 0.1f;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                rotation += 0.1f;
            }

            return rotation;
        }

        private static Vector2 GetMouseAimDirection()
        {
            Vector2 direction = MousePosition - PlayerShip.Instance.Position;

            if (direction == Vector2.Zero)
                return Vector2.Zero;
            else
                return Vector2.Normalize(direction);
        }
    }
}
