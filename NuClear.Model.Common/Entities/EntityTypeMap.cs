using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuClear.Model.Common.Entities
{
    public static class EntityTypeMap
    {
        public static IReadOnlyDictionary<IEntityType, Type> EntitiesMapping
        {
            get { return EntityTypeMappingRegistry.Mappings; }
        }

        public static bool TryGetEntityType(this IEntityType entityName, out Type entityType)
        {
            entityType = null;
            return !entityName.IsVirtual() && EntityTypeMappingRegistry.Mappings.TryGetValue(entityName, out entityType);
        }

        public static bool TryGetEntityName(this Type type, out IEntityType entityName)
        {
            entityName = EntityType.Instance.None();

            // FIXME {d.ivanov, 11.11.2014}: Восстановить логику
            /*
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(RegardingObject<>))
            {
                entityName = EntityType.RegardingObjectReference;
                return true;
            }
             */

            var reverseMappings = EntityTypeMappingRegistry.Mappings.ToDictionary(x => x.Value, x => x.Key);
            return !type.IsPersistenceOnly() && reverseMappings.TryGetValue(type, out entityName);
        }

        public static Type AsEntityType(this IEntityType entityName)
        {
            Type type;
            if (!entityName.TryGetEntityType(out type))
            {
                throw new ArgumentException(string.Format("Cannot find type mapped to IEntityType {0}", entityName));
            }

            return type;
        }

        public static IEntityType AsEntityName(this Type entityType)
        {
            IEntityType entityName;
            if (!entityType.TryGetEntityName(out entityName))
            {
                throw new ArgumentException(string.Format("Cannot find IEntityType mapped to type {0}", entityType.Name));
            }

            return entityName;
        }

        public static IEntityType[] AsEntityTypes(this Type[] entitiesTypes)
        {
            return Convert2EntityNames(entitiesTypes);
        }

        public static EntitySet AsEntitySet(this Type[] entitiesTypes)
        {
            return Convert2EntityNames(entitiesTypes).ToEntitySet();
        }

        private static IEntityType[] Convert2EntityNames(params Type[] entitiesTypes)
        {
            var sb = new StringBuilder();
            var entityNames = new IEntityType[entitiesTypes.Length];
            for (var index = 0; index < entitiesTypes.Length; index++)
            {
                var entitiesType = entitiesTypes[index];
                IEntityType entityName;
                if (!entitiesType.TryGetEntityName(out entityName))
                {
                    sb.AppendFormat(
                        "Can't find entity name for specified type {0}. Entity type is persistance only:{1}. Check domain model",
                        entitiesType,
                        entitiesType.IsPersistenceOnly());
                }

                entityNames[index] = entityName;
            }

            if (sb.Length > 0)
            {
                throw new InvalidOperationException(sb.ToString());
            }

            return entityNames;
        }
    }
}
