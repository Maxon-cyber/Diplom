using System.Data;

namespace OnlineStore.Domain.Attributes;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class ColumnDataAttribute() : Attribute
{
    public string ColumnName { get; set; }

    public SqlDbType SqlDbType { get; set; }
}