using OnlineStore.Domain.Attributes;
using System.Data;

namespace OnlineStore.Domain;

public abstract class Entity
{
    [ColumnData(ColumnName = "id", SqlDbType = SqlDbType.BigInt)]
    public ulong Id { get; set; }

    [ColumnData(ColumnName = "time_created", SqlDbType = SqlDbType.DateTime2)]
    public DateTime TimeCreated { get; init; }

    [ColumnData(ColumnName = "last_acces_time", SqlDbType = SqlDbType.DateTime2)]
    public DateTime LastAccesTime { get; init; }

    [ColumnData(ColumnName = "last_update_time", SqlDbType = SqlDbType.DateTime2)]
    public DateTime LastUpdateTime { get; init; }
}