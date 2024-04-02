using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.DataAccess.Providers.Relational.Abstractions;
using OnlineStore.Domain.User;

namespace OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.User;

public sealed class UserRepository(DbProvider dbProvider) : IUserRepository
{
    public string Provider => dbProvider.Provider;

    public ADORepository<UserEntity> ADO { get; } = new ADORepository<UserEntity>(dbProvider);
}