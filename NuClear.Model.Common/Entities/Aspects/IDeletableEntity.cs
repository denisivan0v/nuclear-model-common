namespace NuClear.Model.Common.Entities.Aspects
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}
