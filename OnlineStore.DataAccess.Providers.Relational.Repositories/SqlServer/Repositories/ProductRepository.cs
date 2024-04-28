using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using OnlineStore.Domain.Product;

namespace OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer.Repositories;

public sealed class ProductRepository(SqlServerProvider sqlServer) : IRepository<ProductEntity>
{
    public Task<DbResponse<ProductEntity>> GetByAsync(QueryParameters queryParameters, ProductEntity productCondition, CancellationToken token)
        => sqlServer.GetByAsync(queryParameters, productCondition, token);

    public Task<DbResponse<ProductEntity>> SelectAsync(QueryParameters queryParameters, CancellationToken token)
        => sqlServer.SelectAsync<ProductEntity>(queryParameters, token);

    public Task<DbResponse<ProductEntity>> SelectByAsync(QueryParameters queryParameters, ProductEntity productCondition, CancellationToken token)
        => sqlServer.SelectByAsync(queryParameters, productCondition, token);

    public Task<DbResponse<ProductEntity>> ChangeAsync(QueryParameters queryParameters, ProductEntity product, CancellationToken token)
        => sqlServer.ChangeAsync(queryParameters, product, token);

    public Task<DbResponse<ProductEntity>> ChangeAsync(QueryParameters queryParameters, IEnumerable<ProductEntity> products, CancellationToken token)
        => sqlServer.ChangeAsync(queryParameters, products, token);

    public void Dispose()
        => sqlServer.Dispose();

    public async ValueTask DisposeAsync()
        => await sqlServer.DisposeAsync();
}