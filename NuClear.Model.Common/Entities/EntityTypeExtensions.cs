using System.Globalization;
using System.Resources;

namespace NuClear.Model.Common.Entities
{
    public static class EntityTypeExtensions
    {
        public static EntityTypeAll All(this EntityType entityType)
        {
            return EntityTypeAll.Instance;
        }

        public static EntityTypeNone None(this EntityType entityType)
        {
            return EntityTypeNone.Instance;
        }

        public static string ToStringLocalized(this IEntityType value, ResourceManager resourceManager, CultureInfo cultureInfo)
        {
            var type = value.GetType();
            var name = value.Description;

            if (resourceManager == null)
            {
                return name;
            }

            var localizedName = resourceManager.GetString(type.Name + name, cultureInfo);
            return localizedName ?? name;
        }
    }
}