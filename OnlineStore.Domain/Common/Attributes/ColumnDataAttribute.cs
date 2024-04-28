using System.Data;

namespace OnlineStore.Domain.Common.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
public sealed class ColumnDataAttribute() : Attribute
{
    public string ColumnName { get; set; } = string.Empty;

    public DbType DbType { get; set; } = DbType.String;
}