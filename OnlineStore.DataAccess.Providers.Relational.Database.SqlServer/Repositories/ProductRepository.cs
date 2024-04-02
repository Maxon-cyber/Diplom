using Microsoft.Data.SqlClient;
using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.Domain.Product;
using System.Data;

namespace OnlineStore.DataAccess.Providers.Relational.Database.SqlServer.Repositories;

public sealed class ProductRepository(SqlConnection dbConnection, SqlCommand dbCommand, string parameterPrefix) : IRepository<ProductEntity>
{
    private readonly ADODataAccessService<ProductEntity> _ado = new ADODataAccessService<ProductEntity>(dbConnection, dbCommand, parameterPrefix);

    public Task<DbResponse<ProductEntity>> GetByAsync(string command, CommandType commandType, ProductEntity productCondition, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<DbResponse<ProductEntity>> SelectAsync(string command, CommandType commandType, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<DbResponse<ProductEntity>> SelectByAsync(string command, CommandType commandType, ProductEntity productCondition, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<DbResponse<ProductEntity>> UpdateAsync(string command, CommandType commandType, ProductEntity product, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<DbResponse<ProductEntity>> UpdateAsync(string command, CommandType commandType, List<ProductEntity> products, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _ado.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _ado.DisposeAsync();
    }
}