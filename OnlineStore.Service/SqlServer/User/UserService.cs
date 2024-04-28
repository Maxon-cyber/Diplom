using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Database.SqlServer.Queries;
using OnlineStore.DataAccess.Providers.Relational.Repositories.SqlServer.Repositories;
using OnlineStore.Domain.User;
using OnlineStore.Service.Caching;
using OnlineStore.Service.Common;
using System.Collections.Immutable;
using System.Data;

namespace OnlineStore.Service.SqlServer.User;

public sealed class UserService : IUserService
{
    private readonly CachedFileManager<UserEntity> _cache;
    private readonly UserRepository _userRepository;
    private readonly CancellationToken _cancellationToken;

    public UserService(UserRepository userRepository, ILo)
    {
        //_cache = new CachedFileManager<UserEntity>();
        _userRepository = userRepository;
    }

    public async Task<UserEntity?> GetByAsync(UserEntity userCondition)
    {
        //if (await _cache.ContainsAsync("User", userCondition))
        //    return await _cache.ReadAsync("User");

        DbResponse<UserEntity> result = await _userRepository.GetByAsync(new QueryParameters()
        {
            CommandText = SqlServerStoredProcedureList.GetUserByCondition,
            CommandType = CommandType.StoredProcedure,
            TransactionManagementOnDbServer = true
        },
        userCondition,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<UserEntity>(null);
        }

        UserEntity user = result.QueryResult.Peek();

        await _cache.WriteAsync("User", user);

        return user;
    }

    public async Task<IEnumerable<UserEntity>?> SelectAsync()
    {
        DbResponse<UserEntity> result = await _userRepository.SelectAsync(new QueryParameters()
        {
            CommandText = SqlServerStoredProcedureList.GetAllUsers,
            CommandType = CommandType.StoredProcedure,
            TransactionManagementOnDbServer = true
        },
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<UserEntity>?>(null);
        }

        //_logger.LogInformation($"Сущности получены");
        //foreach (TEntity currentEntity in result.Data)
        //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");

        return result.QueryResult;
    }

    public async Task<IEnumerable<UserEntity>?> SelectByAsync(UserEntity userCondition)
    {
        //_logger.LogInformation("Запрос на получение сущностей\n".ToUpper() +
        //$"\tТип сущностей: {typeof(TEntity)}");

        DbResponse<UserEntity> result = await _userRepository.SelectByAsync(new QueryParameters()
        {
            CommandText = SqlServerStoredProcedureList.GetUsersByCondition,
            CommandType = CommandType.StoredProcedure,
            TransactionManagementOnDbServer = true
        },
        userCondition,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<UserEntity>?>(null);
        }

        IImmutableQueue<UserEntity> data = result.QueryResult;
        if (!data.IsEmpty)
        {
            //_logger.LogInformation("Сущности получены:");
            //foreach (TEntity currentEntity in data)
            //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");
        }

        return data;
    }

    public async Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, UserEntity user)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                      $"\tТип сущности: {typeof(TEntity)}\n" +
        //                      "\tКоличество сущностей на обновление: 1");

        string command = typeOfCommand switch
        {
            TypeOfEntityUpdateCommand.Insert => SqlServerStoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Update => SqlServerStoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Delete => SqlServerStoredProcedureList.DropUser,
        };

        DbResponse<UserEntity> result = await _userRepository.ChangeAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = CommandType.StoredProcedure,
            TransactionManagementOnDbServer = true,
            OutputParameter = new ReceivedQueryParameter()
            {
                ValueName = "@result",
                DbTypeOfValue = DbType.String,
                Size = -1,
                ParameterDirection = ParameterDirection.Output
            },
            ReturnedValue = new ReceivedQueryParameter()
            {
                ValueName = "@returned_value",
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.ReturnValue
            }
        },
        user,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return false;
        }

        //int countOfAddedRows = addedData.Values.Count(value => value == true);
        //int countOfPropertiesEntity = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length;

        //if (countOfAddedRows == countOfPropertiesEntity)
        //{
        //    //_logger.LogInformation($"Сущности обновлены (число обновленных сущностей: {countOfAddedRows})");
        //    return true;
        //}

        //_logger.LogInformation($"Количество обновленных сущностей: {countOfAddedRows} из {countOfPropertiesEntity}");

        //_logger.LogInformation("Не обновленные сущности:");
        //foreach (KeyValuePair<TEntity, object> currentEntity in addedData.Where(value => value.Value == false))
        //{
        //    TEntity keyOfCurrentEntity = currentEntity.Key;
        //    //_logger.LogInformation($"\tId сущности: {keyOfCurrentEntity.Id}");
        //}

        return false;
    }

    public async Task<bool> UpdateAsync(TypeOfEntityUpdateCommand typeOfCommand, List<UserEntity> users)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                       $"\tТип сущности: {typeof(TEntity)}\n" +
        //                       $"\tКоличество сущностей на обновление: {entities.Count}");

        string command = typeOfCommand switch
        {
            TypeOfEntityUpdateCommand.Insert => SqlServerStoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Update => SqlServerStoredProcedureList.AddUser,
            TypeOfEntityUpdateCommand.Delete => SqlServerStoredProcedureList.DropUser,
        };

        DbResponse<UserEntity> result = await _userRepository.ChangeAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = CommandType.StoredProcedure,
            TransactionManagementOnDbServer = true,
            OutputParameter = new ReceivedQueryParameter()
            {
                ValueName = "@result",
                Size = -1,
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.Output
            },
            ReturnedValue = new ReceivedQueryParameter()
            {
                ValueName = "@returned_value",
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.ReturnValue
            }
        },
        users,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return false;
        }

        //if (addedData.All(data => data.Value == true))
        //{
        //    //_logger.LogInformation($"Сущности обновлены(число обновленных сущностей: {countOfAddedRows})");
        //    return true;
        //}

        //_logger.LogInformation($"Количество обновленных сущностей: {countOfAddedRows} из {countOfPropertiesEntity}");

        //_logger.LogInformation("Не обновленные сущности:");
        //foreach (KeyValuePair<TEntity, object> currentEntity in addedData.Where(value => value.Value == false))
        //{
        //    TEntity keyOfCurrentEntity = currentEntity.Key;
        //    //_logger.LogInformation($"\tId cущности{keyOfCurrentEntity.Id}");
        //}

        return false;
    }

    public void Dispose()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        _userRepository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        await _userRepository.DisposeAsync();
    }
}