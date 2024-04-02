using OnlineStore.DataAccess;
using OnlineStore.Domain.Product;
using OnlineStore.Service.Common;
using OnlineStore.Service.Common.Abstractions;

namespace OnlineStore.Service.Product;

public sealed class ProductService(DatabaseFacade databaseFacade) 
    : Service<ProductEntity>(databaseFacade.Relational.SqlServer.ProductRepository), IProductService
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
        databaseFacade.Dispose();
        base.Dispose();
    }

    public new async ValueTask DisposeAsync()
    {
        await databaseFacade.DisposeAsync();
        await base.DisposeAsync();
    }
}