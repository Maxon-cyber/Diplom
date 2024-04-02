using OnlineStore.Domain.Attributes;
using OnlineStore.Domain.Product;
using System.Data;

namespace OnlineStore.Domain.Order;

public sealed class OrderEntity : Entity
{
    [ColumnData(ColumnName = "user_id", SqlDbType = SqlDbType.BigInt)]
    public ulong UserId { get; init; }

    [ColumnData(ColumnName = "products", SqlDbType = SqlDbType.Xml)]
    public IList<ProductEntity> Products { get; init; }

    [ColumnData(ColumnName = "total_amount", SqlDbType = SqlDbType.Money)]
    public decimal TotalAmount { get; init; }

    [ColumnData(ColumnName = "order_date", SqlDbType = SqlDbType.SmallDateTime)]
    public DateTime OrderDate { get; init; }

    [ColumnData(ColumnName = "status", SqlDbType = SqlDbType.NChar)]
    public Status Status { get; init; }
}