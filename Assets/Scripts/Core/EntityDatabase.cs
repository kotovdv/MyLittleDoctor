using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Core
{
    public class EntityDatabase
    {
        private readonly Dictionary<string, Entity.Entity> _entities = new Dictionary<string, Entity.Entity>();

        public void Register(Entity.Entity entity) {
            var id = Guid.NewGuid().ToString();
            while (_entities.ContainsKey(id)) { }

            entity.Id = id;
            _entities[id] = entity;
        }

        public T Get<T>(string id) where T : Entity.Entity {
            var entity = Find<T>(id);
            if (entity == null)
                throw new Exception($"Failed to retrieve entity with id {id}");

            return entity;
        }

        [CanBeNull]
        private T Find<T>(string id) where T : Entity.Entity {
            if (!_entities.TryGetValue(id, out var result))
                return null;

            return (T) result;
        }
    }
}