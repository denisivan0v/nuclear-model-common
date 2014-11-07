using System.Collections.Generic;
using System.Linq;

namespace NuClear.Model.Common.Entities
{
    public static class EntitySetExtension
    {
        public static EntitySet ToEntitySet(this IEntityName entityName)
        {
            return new EntitySet(new[] { entityName });
        }

        public static EntitySet ToEntitySet(this IEntityName[] entityNames)
        {
            return new EntitySet(entityNames);
        }

        public static EntitySet Merge(this IEnumerable<EntitySet> descriptors)
        {
            return new EntitySet(descriptors.SelectMany(d => d.Entities).Distinct().ToArray());
        }
    }
}