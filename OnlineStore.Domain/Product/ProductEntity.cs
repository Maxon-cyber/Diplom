using OnlineStore.Domain.Attributes;
using System.Data;

namespace OnlineStore.Domain.Product;

public sealed class ProductEntity() : Entity
{
    [ColumnData(ColumnName = "name", SqlDbType = SqlDbType.NVarChar)]
    public string Name { get; init; }

    [ColumnData(ColumnName = "image", SqlDbType = SqlDbType.VarBinary)]
    public byte[] Image { get; init; }

    [ColumnData(ColumnName = "count", SqlDbType = SqlDbType.Int)]
    public uint Quantity { get; init; }

    [ColumnData(ColumnName = "category", SqlDbType = SqlDbType.NVarChar)]
    public string Category { get; init; }

    [ColumnData(ColumnName = "price", SqlDbType = SqlDbType.Money)]
    public decimal Price { get; init; }

    public string ToString(string message)
        => $"{Name}-{Price}({message})";

    public override string ToString()
        => $"{Name}-{Price}";

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();
}