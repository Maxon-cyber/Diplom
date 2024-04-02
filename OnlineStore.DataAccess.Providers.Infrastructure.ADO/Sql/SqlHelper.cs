using System.Data;

namespace OnlineStore.DataAccess.Providers.Infrastructure.ADO.Sql;

internal static class SqlHelper
{
    internal static (object Value, Type SqlDbType) ConvertCLRTypeToSqlDbType(object value, SqlDbType sqlDbType)
    {
        Type dbType = sqlDbType switch
        {
            SqlDbType.BigInt => typeof(long),
            SqlDbType.NChar => typeof(string),
            SqlDbType.DateTime => typeof(DateTime),
            SqlDbType.Image => typeof(byte[]),
            SqlDbType.Money => typeof(decimal),
            _ => throw new ArgumentOutOfRangeException(nameof(sqlDbType))
        };

        return (Convert.ChangeType(value, dbType), dbType);
    }

    internal static object? ConvertSqlDbTypeToCLRType(object value, Type type)
        => Convert.ChangeType(value, type);
}