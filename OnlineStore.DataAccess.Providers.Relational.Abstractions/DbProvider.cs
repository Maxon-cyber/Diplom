using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common.Models;
using OnlineStore.Domain;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Relational.Abstractions;

public abstract class DbProvider(ConnectionParameters connectionParameters) : IDisposable, IAsyncDisposable
{
    protected readonly ConnectionParameters _connectionParameters = connectionParameters;
    
    protected DbConnection _dbConnection;
    protected DbCommand _dbCommand;

    public abstract string Prefix { get; }

    public abstract string Provider { get; }

    public abstract DbConnection DbConnection { get; }

    public abstract DbCommand DbCommand { get; }

    public abstract Task<DbResponse<TEntity>> GetByAsync<TEntity>(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token)
        where TEntity : Entity;

    public abstract Task<DbResponse<TEntity>> SelectAsync<TEntity>(QueryParameters queryParameters, CancellationToken token)
        where TEntity : Entity;

    public abstract Task<DbResponse<TEntity>> SelectByAsync<TEntity>(QueryParameters queryParameters, TEntity entityCondition, CancellationToken token)
        where TEntity : Entity;

    public abstract Task<DbResponse<TEntity>> ChangeAsync<TEntity>(QueryParameters queryParameters, TEntity entity, CancellationToken token)
        where TEntity : Entity;

    public abstract Task<IEnumerable<DbResponse<TEntity>>> ChangeAsync<TEntity>(QueryParameters queryParameters, IEnumerable<TEntity> entities, CancellationToken token)
        where TEntity : Entity;

    public abstract void Dispose();

    public abstract ValueTask DisposeAsync();
}