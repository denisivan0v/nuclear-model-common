using System;

namespace NuClear.Model.Common.Entities.Aspects.Integration
{
    public interface IReplicableEntity : IEntityKey
    {
        Guid ReplicationCode { get; set; }
    }
}