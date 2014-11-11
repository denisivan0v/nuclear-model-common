using System;
using System.Collections.Generic;

namespace NuClear.Model.Common.Entities
{
    internal class EntityTypeInstancesStorage
    {
        private readonly Lazy<Dictionary<Type, EntityType>> _storage = new Lazy<Dictionary<Type, EntityType>>();

        public int Count
        {
            get { return _storage.Value.Count; }
        }

        public void Add(EntityType item)
        {
            _storage.Value.Add(item.GetType(), item);
        }

        public bool Contains(Type itemType)
        {
            return _storage.Value.ContainsKey(itemType);
        }

        public bool TryGetInstance<TInstance>(Type itemType, out TInstance value) where TInstance : EntityType
        {
            EntityType entityType;
            _storage.Value.TryGetValue(itemType, out entityType);
            
            value = entityType as TInstance;
            return value != null;
        }
    }
}