namespace NuClear.Model.Common.Entities.Aspects
{
    /// <summary>
    /// Маркерный интерфейс сущности. Может помечаться любая сущность, которую поддерживает engine ERM - т.е. умеет обрабатывать через DAL и т.д., 
    /// может быть как элементом основной Domain model, так и элементом Simplified model
    /// </summary>
    public interface IEntity
    {
    }
}
