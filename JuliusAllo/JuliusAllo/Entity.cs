using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuliusAllo
{
    abstract class Entity
    {
        protected Texture2D image;
        // The tint of the image. This will also allow us to change the transparency.
        protected Color color = Color.White;

        public Vector2 Position;
        public Vector2 Speed = Vector2.One;
        public float Orientation;
        public float Radius = 20;   // used for circular collision detection
        public bool IsExpired;      // true if the entity was destroyed and should be deleted.

        public float ImageScale = 1f;

        public Vector2 RealSize
        {
            get
            {
                return image == null ? Vector2.Zero : new Vector2(image.Width, image.Height);
            }
        }

        public Vector2 Size
        {
            get
            {
                return RealSize * ImageScale;
            }
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Position, null, color, Orientation, RealSize / 2f, ImageScale, 0, 0);
        }
    }
}
