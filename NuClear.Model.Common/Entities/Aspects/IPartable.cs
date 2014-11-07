using System.Collections.Generic;

namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IPartable
    {
        IEnumerable<IEntityPart> Parts { get; set; }
    }
}