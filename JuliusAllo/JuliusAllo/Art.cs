using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace JuliusAllo
{
    static class Art
    {
        public static Texture2D Player { get; private set; }
        public static Texture2D BaseEnemy { get; private set; }
        public static Texture2D Pointer { get; private set; }


        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Art/Player");
            Pointer = content.Load<Texture2D>("Art/Pointer");
            BaseEnemy = content.Load<Texture2D>("Cat");
        }
    }
}
