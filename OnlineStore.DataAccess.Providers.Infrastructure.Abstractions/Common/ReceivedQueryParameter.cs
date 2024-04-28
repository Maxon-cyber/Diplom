using System.Data;

namespace OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;

public sealed class ReceivedQueryParameter
{
    private int _size;

    public required string? ValueName { get; set; }

    public int Size 
    { 
        get
        {
            if (_size == 0 && (DbTypeOfValue == DbType.AnsiString || DbTypeOfValue == DbType.AnsiStringFixedLength || DbTypeOfValue == DbType.String || DbTypeOfValue == DbType.Xml))
                throw new ArgumentException($"Для параметра типа {DbTypeOfValue} требуется установить размер");

            return _size;
        }
        set => _size = value;
    }

    public required DbType DbTypeOfValue { get; set; }

    public required ParameterDirection ParameterDirection { get; set; }
}