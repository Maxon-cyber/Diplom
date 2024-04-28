namespace OnlineStore.Service.Serializer.Abstractions;

public interface IObjectSerializer
{
    string Serialze<TObject>(TObject obj)
        where TObject : class;

    IEnumerable<TObject> Deserialize<TObject>(string input)
        where TObject : class;

    TObject? DeserializeByKey<TObject>(string input, string key)
        where TObject : class;
}