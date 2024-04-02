using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.Domain.Product;

namespace OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.Product;

public interface IProductRepository : ISqlServerRepository
{
    ADORepository<ProductEntity> ADO { get; }
}