using System;
using System.Collections.Generic;

namespace NuClear.Model.Common.Entities
{
    // TODO {d.ivanov, 12.11.2014}: analyze all assemblies in AppDomain and grab all EntityType derived types
    public class EntityTypeInstancesStorage
    {
        private readonly Lazy<Dictionary<Type, EntityType>> _storage = new Lazy<Dictionary<Type, EntityType>>();

        internal EntityTypeInstancesStorage()
        {
        }

        public void Add(EntityType item)
        {
            _storage.Value.Add(item.GetType(), item);
        }

        public bool Contains(EntityType entityType)
        {
            return _storage.Value.ContainsKey(entityType.GetType());
        }

        public bool TryGetInstance<TInstance>(Type itemType, out TInstance value) where TInstance : EntityType
        {
            EntityType entityType;
            _storage.Value.TryGetValue(itemType, out entityType);
            
            value = entityType as TInstance;
            return value != null;
        }

        public IEnumerable<EntityType> GetAllInstances()
        {
            return _storage.Value.Values;
        }
    }
}