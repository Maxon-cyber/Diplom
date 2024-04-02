using OnlineStore.DataAccess.Providers.Infrastructure.ADO.Sql;
using OnlineStore.Domain;
using OnlineStore.Domain.Attributes;
using System.Data.Common;
using System.Reflection;

namespace OnlineStore.DataAccess.Providers.Infrastructure.ADO.Extensions;

internal static class DatabaseExtensions
{
    internal static async Task<int> AddWithValueAsync<TEntity>(this DbCommand command, TEntity model, string parameterPrefix)
        where TEntity : Entity, new()
    {
        if (model == null)
            throw new ArgumentNullException(nameof(model), "Параметр не проинициализирован");

        int countOfAddedValues = 0;

        await Task.Run(() =>
        {
            foreach (PropertyInfo property in model.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ColumnDataAttribute attribute = property.GetCustomAttribute<ColumnDataAttribute>()!;

                (object value, Type sqlType) = SqlHelper.ConvertCLRTypeToSqlDbType(property.GetValue(model)!, attribute.SqlDbType);

                if (value != null && !value.Equals(sqlType.IsValueType ? Activator.CreateInstance(sqlType) : null))
                {
                    DbParameter parameter = command.CreateParameter();
                    parameter.ParameterName = $"{parameterPrefix}{attribute.ColumnName}";
                    parameter.Value = value;

                    command.Parameters.Add(parameter);
                }

                Interlocked.Increment(ref countOfAddedValues);
            }
        });

        return countOfAddedValues;
    }

    internal static async Task<TEntity> MappingAsync<TEntity>(this DbDataReader dbDataReader)
        where TEntity : Entity, new()
    {
        TEntity entity = new TEntity();

        await Task.Run(() =>
        {
            Dictionary<string, object> columnNamesAndValues = [];

            for (int index = 0; index < dbDataReader.VisibleFieldCount; index++)
                columnNamesAndValues.Add(dbDataReader.GetName(index), dbDataReader.GetValue(index));

            foreach (PropertyInfo property in entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                ColumnDataAttribute attribute = property.GetCustomAttribute<ColumnDataAttribute>()!;
                string columnName = attribute.ColumnName;

                if (!columnNamesAndValues.ContainsKey(columnName))
                    continue;

                object? value = SqlHelper.ConvertSqlDbTypeToCLRType(columnNamesAndValues[columnName], property.PropertyType);

                property.SetValue(entity, value);
            }
        });

        return entity;
    }
}