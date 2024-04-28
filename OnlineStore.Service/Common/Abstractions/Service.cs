using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.Domain;
using OnlineStore.Service.Caching_Abstractions;
using System.Collections.Immutable;
using System.Data;

namespace OnlineStore.Service.Common.Abstractions;

public abstract class Service<TEntity> : IService<TEntity>
    where TEntity : Entity, new()
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly ICache<TEntity> _cache;
    protected readonly CancellationToken _cancellationToken;

    protected Service(IRepository<TEntity> repository)
    {
        _repository = repository;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = cancellationTokenSource.Token;
    }

    public virtual async Task<TEntity?> GetEntityByAsync(string command, CommandType commandType, TEntity entityCondition)
    {
        //_logger.LogInformation("Запрос на получение сущности\n".ToUpper() +
        //$"\tТип сущности: {typeof(TEntity)}");

        if (await _cache.ContainsAsync(entityCondition))
            return _cache.Read();

        DbResponse<TEntity> result = await _repository.GetByAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = commandType,
            TransactionManagementOnDbServer = true,
        },
        entityCondition,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<TEntity>(null);
        }

        TEntity entity = result.QueryResult.Peek();
        //_logger.LogInformation($"Сущность получена:\n" +
        //$"\tId сущности:{entity.Id}");

        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>?> SelectEntitiesAsync(string command, CommandType commandType)
    {
        //_logger.LogInformation("Запрос на получение сущностей\n".ToUpper() +
        //$"\tТип сущностей: {typeof(TEntity)}");

        if (_cache.Contains())
            return _cache.Read();

        DbResponse<TEntity> result = await _repository.SelectAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = commandType,
            TransactionManagementOnDbServer = true,
            OutputParameter = new ReceivedQueryParameter()
            {
                ValueName = "@result",
                Size = -1,
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.Output
            },
        },
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<TEntity>?>(null);
        }

        //_logger.LogInformation($"Сущности получены");
        //foreach (TEntity currentEntity in result.Data)
        //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");

        return result.QueryResult;
    }

    public virtual async Task<IEnumerable<TEntity>?> SelectEntitiesByAsync(string command, CommandType commandType, TEntity entityCondition)
    {
        //_logger.LogInformation("Запрос на получение сущностей\n".ToUpper() +
        //$"\tТип сущностей: {typeof(TEntity)}");

        DbResponse<TEntity> result = await _repository.SelectByAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = commandType,
            TransactionManagementOnDbServer = true,
            OutputParameter = new ReceivedQueryParameter()
            {
                ValueName = "@result",
                Size = -1,
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.Output
            },
        },
        entityCondition,
        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<TEntity>?>(null);
        }

        IImmutableQueue<TEntity> data = result.QueryResult;
        if (!data.IsEmpty)
        {
            //_logger.LogInformation("Сущности получены:");
            //foreach (TEntity currentEntity in data)
            //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");
        }

        return data;
    }

    public virtual async Task<bool> UpdateEntityAsync(string command, CommandType commandType, TEntity entity)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                      $"\tТип сущности: {typeof(TEntity)}\n" +
        //                      "\tКоличество сущностей на обновление: 1");

        DbResponse<TEntity> result = await _repository.ChangeAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = commandType,
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
        entity,
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

    public virtual async Task<bool> UpdateEntityAsync(string command, CommandType commandType, List<TEntity> entities)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                       $"\tТип сущности: {typeof(TEntity)}\n" +
        //                       $"\tКоличество сущностей на обновление: {entities.Count}");

        DbResponse<TEntity> result = await _repository.ChangeAsync(new QueryParameters()
        {
            CommandText = command,
            CommandType = commandType,
            TransactionManagementOnDbServer = true,
            OutputParameter = new ReceivedQueryParameter()
            {
                ValueName = "@result",
                Size = -1,
                DbTypeOfValue = DbType.Int32,
                ParameterDirection = ParameterDirection.Output
            },
        },
        entities,
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
    }

    public async ValueTask DisposeAsync()
    {
        GC.Collect();
        GC.SuppressFinalize(this);
    }
}