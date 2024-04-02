using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.Domain;
using System.Data;

namespace OnlineStore.DataAccess.Providers.Infrastructure.Abstractions;

public interface IDataAccessService<TEntity> : IDisposable, IAsyncDisposable
    where TEntity : Entity, new()
{
    Task<DbResponse<TEntity>> GetEntityByAsync(string command, CommandType commandType, TEntity entityCondition, CancellationToken token);

    Task<DbResponse<TEntity>> SelectEntitiesAsync(string command, CommandType commandType, CancellationToken token);

    Task<DbResponse<TEntity>> SelectEntitiesByAsync(string command, CommandType commandType, TEntity entityCondition, CancellationToken token);

    Task<DbResponse<TEntity>> UpdateEntityAsync(string command, CommandType commandType, TEntity entity, CancellationToken token);

    Task<DbResponse<TEntity>> UpdateEntityAsync(string command, CommandType commandType, List<TEntity> entities, CancellationToken token);
}