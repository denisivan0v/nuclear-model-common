namespace NuClear.Model.Common.Entities.Aspects
{
    public interface ICuratedEntity
    {
        long OwnerCode { get; set; }
        long? OldOwnerCode { get; }
    }
}
