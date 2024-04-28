using System.Data;

namespace OnlineStore.DataAccess.Providers.Infrastructure.Abstractions.Common;

public sealed class QueryParameters()
{
    public required string CommandText { get; set; }

    public required CommandType CommandType { get; set; }

    public required bool TransactionManagementOnDbServer { get; set; }

    public ReceivedQueryParameter? OutputParameter { get; set; }

    public ReceivedQueryParameter? ReturnedValue { get; set; }
}