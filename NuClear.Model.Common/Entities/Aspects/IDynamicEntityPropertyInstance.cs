using System;

namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IDynamicEntityPropertyInstance : IEntity
    {
        long EntityInstanceId { get; set; }
        int PropertyId { get; set; }
        string TextValue { get; set; }
        decimal? NumericValue { get; set; }
        DateTime? DateTimeValue { get; set; } 
    }
}