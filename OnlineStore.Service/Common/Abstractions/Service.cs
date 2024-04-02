using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Relational.Abstractions.Common;
using OnlineStore.Domain;
using System.Collections.Immutable;
using System.Data;
using System.Reflection;

namespace OnlineStore.Service.Common.Abstractions;

public abstract class Service<TEntity> : IService<TEntity>
    where TEntity : Entity, new()
{
    protected readonly IRepository<TEntity> _repository;
    protected readonly CancellationToken _cancellationToken;

    protected Service(IRepository<TEntity> repository)
    {
        _repository = repository;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = cancellationTokenSource.Token;
    }

    public async Task<TEntity?> GetEntityByAsync(string command, CommandType commandType, TEntity entityCondition)
    {
        //_logger.LogInformation("Запрос на получение сущности\n".ToUpper() +
                               //$"\tТип сущности: {typeof(TEntity)}");

        DbResponse<TEntity> result = await _repository.GetByAsync(
                                                        command,
                                                        commandType,
                                                        entityCondition,
                                                        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<TEntity>(null);
        }

        TEntity entity = result.Data.Peek();
        //_logger.LogInformation($"Сущность получена:\n" +
                               //$"\tId сущности:{entity.Id}");

        return entity;
    }

    public async Task<IEnumerable<TEntity>> SelectEntitiesAsync(string command, CommandType commandType)
    {
        //_logger.LogInformation("Запрос на получение сущностей\n".ToUpper() +
                               //$"\tТип сущностей: {typeof(TEntity)}");

        DbResponse<TEntity> result = await _repository.SelectAsync(
                                                        command,
                                                        commandType,
                                                        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<TEntity>>(null);
        }

        //_logger.LogInformation($"Сущности получены");
        //foreach (TEntity currentEntity in result.Data)
            //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");

        return result.Data;
    }

    public async Task<IEnumerable<TEntity>> SelectEntitiesByAsync(string command, CommandType commandType, TEntity entityCondition)
    {
        //_logger.LogInformation("Запрос на получение сущностей\n".ToUpper() +
                               //$"\tТип сущностей: {typeof(TEntity)}");

        DbResponse<TEntity> result = await _repository.SelectByAsync(
                                                        command,
                                                        commandType,
                                                        entityCondition,
                                                        _cancellationToken);

        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return await Task.FromResult<IEnumerable<TEntity>>(null);
        }

        IImmutableQueue<TEntity> data = result.Data;
        if (data != null)
        {
            //_logger.LogInformation("Сущности получены:");
            //foreach (TEntity currentEntity in data)
                //_logger.LogInformation($"\tId сущности:{currentEntity.Id}");
        }

        return data;
    }

    public async Task<bool> UpdateEntityAsync(string command, CommandType commandType, TEntity entity)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                      $"\tТип сущности: {typeof(TEntity)}\n" +
        //                      "\tКоличество сущностей на обновление: 1");

        DbResponse<TEntity> result = await _repository.UpdateAsync(
                                                        command,
                                                        commandType,
                                                        entity,
                                                        _cancellationToken);
        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return false;
        }

        IImmutableDictionary<TEntity, bool> addedData = result.AddedData;

        int countOfAddedRows = addedData.Values.Count(value => value == true);
        int countOfPropertiesEntity = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length;

        if (countOfAddedRows == countOfPropertiesEntity)
        {
            //_logger.LogInformation($"Сущности обновлены (число обновленных сущностей: {countOfAddedRows})");
            return true;
        }

        //_logger.LogInformation($"Количество обновленных сущностей: {countOfAddedRows} из {countOfPropertiesEntity}");

        //_logger.LogInformation("Не обновленные сущности:");
        foreach (KeyValuePair<TEntity, bool> currentEntity in addedData.Where(value => value.Value == false))
        {
            TEntity keyOfCurrentEntity = currentEntity.Key;
            //_logger.LogInformation($"\tId сущности: {keyOfCurrentEntity.Id}");
        }

        return false;
    }

    public async Task<bool> UpdateEntityAsync(string command, CommandType commandType, List<TEntity> entities)
    {
        //_logger.LogInformation("Запрос на обновление сущностей\n".ToUpper() +
        //                       $"\tТип сущности: {typeof(TEntity)}\n" +
        //                       $"\tКоличество сущностей на обновление: {entities.Count}");

        DbResponse<TEntity> result = await _repository.UpdateAsync(
                                                        command,
                                                        commandType,
                                                        entities,
                                                        _cancellationToken);
        if (result.Exception != null)
        {
            //_logger.LogError(result.Exception, result.Message);
            return false;
        }

        IImmutableDictionary<TEntity, bool> addedData = result.AddedData;

        int countOfAddedRows = addedData.Count(entity => entity.Value == true);
        int countOfPropertiesEntity = typeof(TEntity).GetProperties(BindingFlags.Instance | BindingFlags.Public).Length * entities.Count;

        if (countOfAddedRows == countOfPropertiesEntity)
        {
            //_logger.LogInformation($"Сущности обновлены(число обновленных сущностей: {countOfAddedRows})");
            return true;
        }

        //_logger.LogInformation($"Количество обновленных сущностей: {countOfAddedRows} из {countOfPropertiesEntity}");

        //_logger.LogInformation("Не обновленные сущности:");
        foreach (KeyValuePair<TEntity, bool> currentEntity in addedData.Where(value => value.Value == false))
        {
            TEntity keyOfCurrentEntity = currentEntity.Key;
            //_logger.LogInformation($"\tId cущности{keyOfCurrentEntity.Id}");
        }
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