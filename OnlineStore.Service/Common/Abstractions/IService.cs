using OnlineStore.Domain;
using System.Data;

namespace OnlineStore.Service.Common.Abstractions;

public interface IService<TEntity> : IDisposable, IAsyncDisposable
    where TEntity : Entity, new()
{
    Task<TEntity?> GetEntityByAsync(string command, CommandType commandType, TEntity condition);

    Task<IEnumerable<TEntity>> SelectEntitiesAsync(string command, CommandType commandType);

    Task<IEnumerable<TEntity>> SelectEntitiesByAsync(string command, CommandType commandType, TEntity condition);

    Task<bool> UpdateEntityAsync(string command, CommandType commandType, TEntity entity);

    Task<bool> UpdateEntityAsync(string command, CommandType commandType, List<TEntity> entities);
}