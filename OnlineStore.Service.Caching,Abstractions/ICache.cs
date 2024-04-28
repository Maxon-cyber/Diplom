namespace OnlineStore.Service.Caching_Abstractions;

public interface ICache<TObject>
{
    Task<IEnumerable<TObject>> ReadAsync(string cacheObjectName);

    Task<IEnumerable<TObject>> ReadByAsync(string cacheObjectName, TObject @object);

    Task<string> WriteAsync(string cacheObjectName, TObject @object);

    Task<string> WriteAsync(string cacheObjectName, ICollection<TObject> objects);

    Task<bool> ContainsAsync(string cacheObjectName, TObject @object);

    Task ClearAsync(string cacheObjectName);
}