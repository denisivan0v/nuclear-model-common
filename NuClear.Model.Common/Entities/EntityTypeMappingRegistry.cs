using System;
using System.Collections.Generic;

namespace NuClear.Model.Common.Entities
{
    public class EntityTypeMappingRegistry
    {
        private static readonly object SyncRoot = new object();
        private static volatile EntityTypeMappingRegistry _singleInstance;

        private readonly IEnumerable<IEntityType> _virtualEntityTypes;
        private readonly IEnumerable<Type> _persistanceEntityClrTypes;
        private readonly Dictionary<IEntityType, Type> _mappings = new Dictionary<IEntityType, Type>();

        private EntityTypeMappingRegistry(IEnumerable<IEntityType> virtualEntityTypes, IEnumerable<Type> persistanceEntityClrTypes)
        {
            _virtualEntityTypes = virtualEntityTypes;
            _persistanceEntityClrTypes = persistanceEntityClrTypes;
        }

        internal static IReadOnlyDictionary<IEntityType, Type> Mappings
        {
            get { return Instance._mappings; }
        }
        
        internal static IEnumerable<IEntityType> VirtualEntityTypes
        {
            get { return Instance._virtualEntityTypes; }
        }

        internal static IEnumerable<Type> PersistanceEntityClrTypes
        {
            get { return Instance._persistanceEntityClrTypes; }
        }

        private static EntityTypeMappingRegistry Instance
        {
            get { return _singleInstance; }
        }

        private static Dictionary<IEntityType, Type> MutableMappings
        {
            get { return Instance._mappings; }
        }
        
        public static void Initialize(IEnumerable<IEntityType> virtualEntityTypes, IEnumerable<Type> persistanceEntityClrTypes)
        {
            if (_singleInstance == null)
            {
                lock (SyncRoot)
                {
                    if (_singleInstance == null)
                    {
                        _singleInstance = new EntityTypeMappingRegistry(virtualEntityTypes, persistanceEntityClrTypes);
                    }
                }
            }
        }

        public static void AddMappings(IEnumerable<KeyValuePair<IEntityType, Type>> pairs)
        {
            foreach (var pair in pairs)
            {
                if (!MutableMappings.ContainsKey(pair.Key))
                {
                    MutableMappings.Add(pair.Key, pair.Value);
                }
            }
        }
    }
}