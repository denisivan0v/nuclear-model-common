using System;
using System.Linq;

namespace NuClear.Model.Common.Entities
{
    public static class EntityTypeUtils
    {
        /// <summary>
        /// Список значений EntityName, являющихся composed - т.е. комбинирующими
        /// </summary>
        public static readonly IEntityType[] ComposedEntityTypes = { EntityType.Instance.None(), EntityType.Instance.All() };

        /// <summary>
        /// Разложить composed значение на составляющие, если на вход передано не composed (элементарное) значение EntityName - возвращается оно без изменений
        /// </summary>
        public static IEntityType[] GetDecomposed(this IEntityType entityName)
        {
            if (entityName.Equals(EntityType.Instance.None()))
            {
                return new IEntityType[0];
            }

            if (entityName.Equals(EntityType.Instance.All()))
            {
                var entityTypes = EntityType.Instance.GetTypes();
                return entityTypes
                    .Except(ComposedEntityTypes)
                    .ToArray();
            }

            return new[] { entityName };
        }

        // TODO {d.ivanov, 26.11.2014}: Возможно ли заэкстендить Type, а не IEntityType?
        public static bool IsVirtual(this IEntityType entityName)
        {
            return EntityTypeMappingRegistry.VirtualEntityTypes.Contains(entityName);
        }

        public static bool IsPersistenceOnly(this Type checkingType)
        {
            return EntityTypeMappingRegistry.PersistanceEntityClrTypes.Contains(checkingType);
        }
    }
}