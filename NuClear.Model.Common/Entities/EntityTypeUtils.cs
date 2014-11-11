using System;

namespace NuClear.Model.Common.Entities
{
    public static class EntityTypeUtils
    {
        /// <summary>
        /// Список значений EntityName, являющихся composed - т.е. комбинирующими
        /// </summary>
        public static readonly EntityType[] ComposedEntityNames = { EntityType.None, EntityType.All };

        /// <summary>
        /// Разложить composed значение на составляющие, если на вход передано не composed (элементарное) значение EntityName - возвращается оно без изменений
        /// </summary>
        public static EntityType[] GetDecomposed(this EntityType entityName)
        {
            if (entityName.Equals(EntityType.None))
            {
                return new EntityType[0];
            }

            if (entityName.Equals(EntityType.All))
            {
                // FIXME {d.ivanov, 11.11.2014}: Восстановить логику
                /*
                var allValues = (EntityName[])Enum.GetValues(typeof(EntityName));
                return allValues
                    .Except(ComposedEntityNames)
                    //.Except(VirtualEntityNames)
                    .ToArray();
                 */
            }

            return new[] { entityName };
        }

        public static bool IsVirtual(this EntityType entityName)
        {
            // FIXME {d.ivanov, 11.11.2014}: Восстановить логику

            /*
            return VirtualEntityNames.Contains(entityName);
             */

            return false;
        }

        public static bool IsPersistenceOnly(this Type checkingType)
        {
            // FIXME {d.ivanov, 11.11.2014}: Восстановить логику
            /*
            return PersistenceOnlyEntities.Contains(checkingType);
             */

            return false;
        }
    }
}