namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IDynamicEntityInstance : IBaseEntity, IEntityKey, IAuditableEntity, IDeactivatableEntity, IDeletableEntity, IStateTrackingEntity
    {
    }
}