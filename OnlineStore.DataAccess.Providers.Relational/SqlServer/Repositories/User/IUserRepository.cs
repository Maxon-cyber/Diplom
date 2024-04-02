using OnlineStore.DataAccess.Providers.Infrastructure.ADO;
using OnlineStore.Domain.User;

namespace OnlineStore.DataAccess.Providers.Relational.SqlServer.Repositories.User;

public interface IUserRepository : ISqlServerRepository
{
    ADORepository<UserEntity> ADO { get; }
}