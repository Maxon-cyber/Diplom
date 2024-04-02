using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions;
using OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Models;
using OnlineStore.DataAccess.Providers.Infrastructure.ADO.Extensions;
using OnlineStore.Domain;
using System.Collections.Immutable;
using System.Data;
using System.Data.Common;

namespace OnlineStore.DataAccess.Providers.Infrastructure.ADO;

public sealed class ADODataAccessService<TEntity>(DbConnection dbConnection, DbCommand dbCommand, string parameterPrefix) : IDataAccessService<TEntity>
    where TEntity : Entity, new()
{
    public async Task<DbResponse<TEntity>> GetEntityByAsync(string command, CommandType commandType, TEntity condition, CancellationToken token)
    {
        DbResponse<TEntity> result = new DbResponse<TEntity>();

        dbCommand.CommandText = command;
        dbCommand.CommandType = commandType;

        try
        {
            await dbConnection.OpenAsync(token);

            await dbCommand.AddWithValueAsync(condition, parameterPrefix);
            await using DbDataReader reader = await dbCommand.ExecuteReaderAsync(token);

            if (reader.HasRows)
            {
                result.Data = [];

                while (await reader.ReadAsync(token))
                    result.Data.Enqueue(await reader.MappingAsync<TEntity>());

                result.Message = "Данные получены";
            }
            else
                result.Message = "Данных нет";
        }
        catch (TimeoutException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}";
        }
        catch (OperationCanceledException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}" +
                                       $"\n\t{ex.CancellationToken}";
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}";
        }

        return result;
    }

    public async Task<DbResponse<TEntity>> SelectEntitiesAsync(string command, CommandType commandType, CancellationToken token)
    {
        DbResponse<TEntity> result = new DbResponse<TEntity>();

        dbCommand.CommandText = command;
        dbCommand.CommandType = commandType;

        try
        {
            await dbConnection.OpenAsync(token);

            await using DbDataReader reader = await dbCommand.ExecuteReaderAsync(token);

            if (reader.HasRows)
            {
                result.Data = [];

                while (await reader.ReadAsync(token))
                    result.Data.Enqueue(await reader.MappingAsync<TEntity>());

                result.Message = "Данные получены";
            }
            else
                result.Message = "Данных нет";
        }
        catch (TimeoutException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}";
        }
        catch (OperationCanceledException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}" +
                                       $"\n\t{ex.CancellationToken}";
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                       $"\n\t{ex.Source}";
        }

        return result;
    }

    public async Task<DbResponse<TEntity>> SelectEntitiesByAsync(string command, CommandType commandType, TEntity condition, CancellationToken token)
    {
        DbResponse<TEntity> result = new DbResponse<TEntity>();

        dbCommand.CommandText = command;
        dbCommand.CommandType = commandType;

        try
        {
            await dbConnection.OpenAsync(token);

            await dbCommand.AddWithValueAsync(condition, parameterPrefix);
            await using DbDataReader reader = await dbCommand.ExecuteReaderAsync(token);

            if (reader.HasRows)
            {
                result.Data = [];

                while (await reader.ReadAsync(token))
                    result.Data.Enqueue(await reader.MappingAsync<TEntity>());

                result.Message = "Данные получены";
            }
            else
                result.Message = "Данных нет";
        }
        catch (TimeoutException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}";
        }
        catch (OperationCanceledException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}" +
                                       $"\n\t{ex.CancellationToken}";
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение: {ex.Message}" +
                                       $"\n\t{ex.Source}";
        }

        return result;
    }

    public async Task<DbResponse<TEntity>> UpdateEntityAsync(string command, CommandType commandType, TEntity entity, CancellationToken token)
    {
        DbResponse<TEntity> result = new DbResponse<TEntity>();

        dbCommand.CommandText = command;
        dbCommand.CommandType = commandType;

        try
        {
            await dbConnection.OpenAsync(token);

            result.AddedData = ImmutableDictionary<TEntity, bool>.Empty;

            int countOfAddedValues = await dbCommand.AddWithValueAsync(entity, parameterPrefix);

            int countOfAddedRows = await dbCommand.ExecuteNonQueryAsync(token);

            result.AddedData.Add(entity, countOfAddedValues == countOfAddedRows);

            result.Message = "Данные обновлены";
        }
        catch (TimeoutException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}";
        }
        catch (OperationCanceledException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}" +
                                        $"\n\t{ex.CancellationToken}";
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}";
        }

        return result;
    }

    public async Task<DbResponse<TEntity>> UpdateEntityAsync(string command, CommandType commandType, List<TEntity> entities, CancellationToken token)
    {
        DbResponse<TEntity> result = new DbResponse<TEntity>();

        dbCommand.CommandText = command;
        dbCommand.CommandType = commandType;

        try
        {
            await dbConnection.OpenAsync(token);

            result.AddedData = ImmutableDictionary<TEntity, bool>.Empty;

            for (int index = 0; index < entities.Count; index++)
            {
                TEntity currentEntity = entities[index];

                int countOfAddedValues = await dbCommand.AddWithValueAsync(currentEntity, parameterPrefix);
                int countOfAddedRows = await dbCommand.ExecuteNonQueryAsync(token);

                result.AddedData.Add(currentEntity, countOfAddedValues == countOfAddedRows);
            }

            result.Message = "Данные обновлены";
        }
        catch (TimeoutException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}";
        }
        catch (OperationCanceledException ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}" +
                                        $"\n\t{ex.CancellationToken}";
        }
        catch (Exception ex)
        {
            result.Exception = ex;
            result.Message = $"Сообщение:\n\t{ex.Message}" +
                                        $"\n\t{ex.Source}";
        }

        return result;
    }

    public void Dispose()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        dbConnection.Dispose();
        dbCommand.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        GC.Collect();
        GC.SuppressFinalize(this);

        await dbConnection.DisposeAsync();
        await dbCommand.DisposeAsync();
    }
}