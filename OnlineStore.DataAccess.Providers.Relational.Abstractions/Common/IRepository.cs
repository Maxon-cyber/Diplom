using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.Domain;
using System.Data;

namespace OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;

public interface IRepository<TEntity> : IDisposable, IAsyncDisposable
    where TEntity : Entity, new()
{
    Task<DbResponse<TEntity>> GetByAsync(string command, CommandType commandType, TEntity entityCondition, CancellationToken token);
    
    Task<DbResponse<TEntity>> SelectAsync(string command, CommandType commandType, CancellationToken token);
    
    Task<DbResponse<TEntity>> SelectByAsync(string command, CommandType commandType, TEntity entityCondition, CancellationToken token);
    
    Task<DbResponse<TEntity>> UpdateAsync(string command, CommandType commandType, TEntity entity, CancellationToken token);

    Task<DbResponse<TEntity>> UpdateAsync(string command, CommandType commandType, List<TEntity> entities, CancellationToken token);
}