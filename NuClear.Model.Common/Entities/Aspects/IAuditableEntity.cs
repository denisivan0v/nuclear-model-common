using System;

namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IAuditableEntity
    {
        long CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        long? ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
