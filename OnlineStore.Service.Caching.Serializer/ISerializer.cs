namespace OnlineStore.Service.Caching.Serializer;

public interface ISerializer
{
    Task Serialize(object @obj);

    TObject Deserialize<TObject>();
}