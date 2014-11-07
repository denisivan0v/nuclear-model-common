namespace NuClear.Model.Common.Entities.Aspects
{
    public interface INonActivityDynamicEntityPropertyInstance : IDynamicEntityPropertyInstance
    {
        long EntityInstanceId { get; set; }
    }
}