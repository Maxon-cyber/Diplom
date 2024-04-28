using OnlineStore.Domain.Product;
using OnlineStore.Service.Common;

namespace OnlineStore.Service.SqlServer.Product;

public interface IProductService : IDisposable, IAsyncDisposable
{
    Task<ProductEntity?> GetByAsync(ProductEntity productCondition);

    Task<IEnumerable<ProductEntity>> SelectAsync();

    Task<IEnumerable<ProductEntity>> SelectByAsync(ProductEntity productCondition);

    Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, ProductEntity product);

    Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, List<ProductEntity> products);
}