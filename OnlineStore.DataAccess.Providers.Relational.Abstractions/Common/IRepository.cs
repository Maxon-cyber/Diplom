using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.Domain;

namespace OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;

public interface IRepository<TEntity> : IDisposable, IAsyncDisposable
    where TEntity : Entity, new()
{
    Task<DbResponse<TEntity>> GetByAsync(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token);

    Task<DbResponse<TEntity>> SelectAsync(QueryParameters queryParameters, CancellationToken token);

    Task<DbResponse<TEntity>> SelectByAsync(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token);

    Task<DbResponse<TEntity>> ChangeAsync(QueryParameters queryParameters, TEntity entity, CancellationToken token);

    Task<DbResponse<TEntity>> ChangeAsync(QueryParameters queryParameters, IEnumerable<TEntity> entities, CancellationToken token);
}