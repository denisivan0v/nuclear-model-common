namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IEntityPart : IEntity, IEntityKey, IAuditableEntity, IStateTrackingEntity, IDeactivatableEntity, IDeletableEntity
    {
        long EntityId { get; set; }
    }
}