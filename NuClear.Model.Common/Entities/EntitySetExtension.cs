using System.Collections.Generic;
using System.Linq;

namespace NuClear.Model.Common.Entities
{
    public static class EntitySetExtension
    {
        public static EntitySet ToEntitySet(this EntityType entityName)
        {
            return new EntitySet(new[] { entityName });
        }

        public static EntitySet ToEntitySet(this EntityType[] entityNames)
        {
            return new EntitySet(entityNames);
        }

        public static EntitySet Merge(this IEnumerable<EntitySet> descriptors)
        {
            return new EntitySet(descriptors.SelectMany(d => d.Entities).Distinct().ToArray());
        }
        public static bool IsOpenSet(this EntitySet entitySet)
        {
            return entitySet.Entities.Contains(EntitySet.OpenEntitiesSetIndicator);
        }

        public static IEnumerable<EntitySet> ToConcreteSets(this EntitySet openEntitySet)
        {
            return new OpenEnitiesSetEnumerator(openEntitySet);
        }
    }
}