using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuliusAllo
{
    static class EntityManager
    {
        static List<Entity> _entities = new List<Entity>();
        public static List<Entity> EntitiesList
        {
            get {return _entities;}
        }

        static bool isUpdating;
        static List<Entity> addedEntities = new List<Entity>();

        public static int Count { get { return _entities.Count; } }

        public static void Add(Entity entity)
        {
            if (!isUpdating)
                _entities.Add(entity);
            else
                addedEntities.Add(entity);
        }

        public static void Update()
        {
            isUpdating = true;

            foreach (var entity in _entities)
                entity.Update();

            isUpdating = false;

            foreach (var entity in addedEntities)
                _entities.Add(entity);

            addedEntities.Clear();

            // remove any expired entities.
            _entities = _entities.Where(x => !x.IsExpired).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in _entities)
                entity.Draw(spriteBatch);
        }
    }
}
