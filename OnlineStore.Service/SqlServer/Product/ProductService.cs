using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer;
using OnlineStore.Domain.Product;
using OnlineStore.Service.Caching;
using OnlineStore.Service.Common;
using OnlineStore.Service.Common.Abstractions;

namespace OnlineStore.Service.SqlServer.Product;

public sealed class ProductService(IRepository<ProductEntity> product)
    : Service<ProductEntity>(new EntityFileCache<ProductEntity>(), product), IProductService
{
    public Task<ProductEntity?> GetByAsync(ProductEntity productCondition)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductEntity>> SelectAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductEntity>> SelectByAsync(ProductEntity productCondition)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, ProductEntity product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, List<ProductEntity> products)
    {
        throw new NotImplementedException();
    }

    public new void Dispose()
    {
        base.Dispose();
    }

    public new async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
    }
}