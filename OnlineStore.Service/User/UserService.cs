using OnlineStore.DataAccess;
using OnlineStore.DataAccess.Databases.Queries;
using OnlineStore.Domain.User;
using OnlineStore.Service.Common;
using OnlineStore.Service.Common.Abstractions;
using System.Data;

namespace OnlineStore.Service.User;

public sealed class UserService(DatabaseFacade databaseFacade) 
    : Service<UserEntity>(databaseFacade.Relational.SqlServer.UserRepository), IUserService
{
    public async Task<UserEntity?> GetByAsync(UserEntity userCondition)
        => await GetEntityByAsync(StoredProcedureList.GetUserByCondition, CommandType.StoredProcedure, userCondition);

    public async Task<IEnumerable<UserEntity>> SelectAsync()
        => await SelectEntitiesAsync(StoredProcedureList.GetAllUsers, CommandType.StoredProcedure);

    public async Task<IEnumerable<UserEntity>> SelectByAsync(UserEntity userCondition)
        => await SelectEntitiesByAsync(StoredProcedureList.GetAllUsersByCondition, CommandType.StoredProcedure, userCondition);

    public async Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, UserEntity user)
        => await UpdateEntityAsync(typeOfCommand switch
        {
            TypeOfEntityUpdateCommand.Insert => StoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Update => StoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Delete => StoredProcedureList.DropUser,
        }, CommandType.StoredProcedure, user);

    public async Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, List<UserEntity> users)
        => await UpdateEntityAsync(typeOfCommand switch
        {
            TypeOfEntityUpdateCommand.Insert => StoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Update => StoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Delete => StoredProcedureList.DropUser,
        }, CommandType.StoredProcedure, users);

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