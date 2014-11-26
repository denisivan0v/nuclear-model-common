using System;
using System.Collections.Generic;
using System.Linq;

namespace NuClear.Model.Common.Entities
{
    // TODO {d.ivanov, 12.11.2014}: analyze all assemblies in AppDomain and grab all IEntityType derived types
    public class EntityType
    {
        private static readonly Lazy<EntityType> SingleInstance = new Lazy<EntityType>(() => new EntityType());
        private readonly EntityTypeInstancesStorage _instancesStorage = new EntityTypeInstancesStorage();

        private EntityType()
        {
        }

        public static EntityType Instance
        {
            get { return SingleInstance.Value; }
        }

        public IEnumerable<IEntityType> GetTypes()
        {
            return _instancesStorage.GetAllInstances();
        }

        public bool TryParse(string description, out IEntityType value)
        {
            var entityTypes = GetTypes();
            value = entityTypes.FirstOrDefault(x => x.Description.Equals(description, StringComparison.OrdinalIgnoreCase));

            return value != null;
        }

        public bool TryParse(int id, out IEntityType value)
        {
            var entityTypes = GetTypes();
            value = entityTypes.FirstOrDefault(x => x.Id == id);

            return value != null;
        }

        public bool TryGet<TEntityType>(out TEntityType entityType) where TEntityType : class, IEntityType, new()
        {
            return _instancesStorage.TryGetInstance(typeof(TEntityType), out entityType);
        }
        
        internal bool TryAdd(IEntityType value)
        {
            if (!_instancesStorage.Contains(value))
            {
                _instancesStorage.Add(value);
                return true;
            }

            return false;
        }
    }
}