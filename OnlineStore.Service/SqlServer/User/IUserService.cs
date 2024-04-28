using OnlineStore.Domain.User;
using OnlineStore.Service.Common;

namespace OnlineStore.Service.SqlServer.User;

public interface IUserService : IDisposable, IAsyncDisposable
{
    Task<UserEntity?> GetByAsync(UserEntity userCondition);

    Task<IEnumerable<UserEntity>?> SelectAsync();

    Task<IEnumerable<UserEntity>?> SelectByAsync(UserEntity userCondition);

    Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, UserEntity user);

    Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, List<UserEntity> users);
}