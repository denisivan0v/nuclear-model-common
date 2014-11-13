using System;
using System.Collections.Generic;

namespace NuClear.Model.Common.Entities
{
    internal class EntityTypeInstancesStorage
    {
        private readonly Dictionary<Type, IEntityType> _storage = new Dictionary<Type, IEntityType>();

        public void Add(IEntityType item)
        {
            _storage.Add(item.GetType(), item);
        }

        public bool Contains(IEntityType entityType)
        {
            return _storage.ContainsKey(entityType.GetType());
        }

        public bool TryGetInstance<TInstance>(Type itemType, out TInstance value) where TInstance : class, IEntityType
        {
            IEntityType entityType;
            _storage.TryGetValue(itemType, out entityType);
            
            value = entityType as TInstance;
            return value != null;
        }

        public IEnumerable<IEntityType> GetAllInstances()
        {
            return _storage.Values;
        }
    }
}