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
    }
}