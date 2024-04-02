using Microsoft.Data.SqlClient;
using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.Domain.User;
using System.Data;

namespace OnlineStore.DataAccess.Providers.Relational.Database.SqlServer.Repositories;

public sealed class UserRepository(SqlConnection dbConnection, SqlCommand dbCommand, string parameterPrefix) : IRepository<UserEntity>
{
    private readonly ADODataAccessService<UserEntity> _ado = new ADODataAccessService<UserEntity>(dbConnection, dbCommand, parameterPrefix);

    public async Task<DbResponse<UserEntity>> GetByAsync(string command, CommandType commandType, UserEntity userCondition, CancellationToken token)
        => await _ado.GetEntityByAsync(command, commandType, userCondition, token);

    public async Task<DbResponse<UserEntity>> SelectAsync(string command, CommandType commandType, CancellationToken token)
        => await _ado.SelectEntitiesAsync(command, commandType, token);

    public async Task<DbResponse<UserEntity>> SelectByAsync(string command, CommandType commandType, UserEntity userCondition, CancellationToken token)
        => await _ado.SelectEntitiesByAsync(command, commandType, userCondition, token);

    public async Task<DbResponse<UserEntity>> UpdateAsync(string command, CommandType commandType, UserEntity user, CancellationToken token)
        => await _ado.UpdateEntityAsync(command, commandType, user, token);

    public async Task<DbResponse<UserEntity>> UpdateAsync(string command, CommandType commandType, List<UserEntity> users, CancellationToken token)
        => await _ado.UpdateEntityAsync(command, commandType, users, token);

    public void Dispose()
    {
        _ado.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _ado.DisposeAsync();
    }
}