namespace NuClear.Model.Common.Entities
{
    public abstract class EntityTypeBase<TConcreteIdentity> : IdentityBase<TConcreteIdentity>, IEntityType
        where TConcreteIdentity : IdentityBase<TConcreteIdentity>, new()
    {
        protected EntityTypeBase()
        {
            EntityType.Instance.TryAdd(this);
        }

        public static explicit operator int(EntityTypeBase<TConcreteIdentity> entityType)
        {
            return entityType.Id;
        }

        public int AsInt32()
        {
            return (int)this;
        }
    }
}