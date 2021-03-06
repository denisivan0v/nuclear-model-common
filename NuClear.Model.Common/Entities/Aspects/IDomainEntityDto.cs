﻿namespace NuClear.Model.Common.Entities.Aspects
{
    /// <summary>
    /// Маркерный интерфейс для Dto, которые используются для формирования ViewModel
    /// </summary>
    public interface IDomainEntityDto : IEntityKey
    {
    }

    public interface IDomainEntityDto<TEntity> : IDomainEntityDto
        where TEntity : class, IEntity, IEntityKey
    {
    }
}