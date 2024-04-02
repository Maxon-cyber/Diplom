using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.Domain.Product;

namespace OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.Product;

public sealed class ProductRepository(DbProvider dbProvider) : IProductRepository
{
    public string Provider => dbProvider.Provider;

    public ADORepository<ProductEntity> ADO { get; } = new ADORepository<ProductEntity>(dbProvider);
}