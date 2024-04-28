using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using OnlineStore.Domain.User;

namespace OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer.Repositories;

public sealed class UserRepository(SqlServerProvider sqlServer) : IRepository<UserEntity>
{
    public Task<DbResponse<UserEntity>> GetByAsync(QueryParameters queryParameters, UserEntity entityCondition, CancellationToken token)
        => sqlServer.GetByAsync(queryParameters, entityCondition, token);

    public Task<DbResponse<UserEntity>> SelectAsync(QueryParameters queryParameters, CancellationToken token)
        => sqlServer.SelectAsync<UserEntity>(queryParameters, token);

    public Task<DbResponse<UserEntity>> SelectByAsync(QueryParameters queryParameters, UserEntity userCondition, CancellationToken token)
        => sqlServer.SelectByAsync(queryParameters, userCondition, token);

    public Task<DbResponse<UserEntity>> ChangeAsync(QueryParameters queryParameters, UserEntity user, CancellationToken token)
        => sqlServer.ChangeAsync(queryParameters, user, token);

    public Task<DbResponse<UserEntity>> ChangeAsync(QueryParameters queryParameters, IEnumerable<UserEntity> users, CancellationToken token)
        => sqlServer.ChangeAsync(queryParameters, users, token);

    public void Dispose()
        => sqlServer.Dispose();

    public async ValueTask DisposeAsync()
        => await sqlServer.DisposeAsync();
}