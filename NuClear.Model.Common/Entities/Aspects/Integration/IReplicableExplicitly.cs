namespace NuClear.Model.Common.Entities.Aspects.Integration
{
    /// <summary>
    /// for entities, that have no replication code, but should be replicated
    /// </summary>
    public interface IReplicableExplicitly : IEntityKey
    {
    }
}