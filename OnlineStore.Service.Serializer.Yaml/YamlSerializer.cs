using OnlineStore.Service.Serializer.Abstractions;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OnlineStore.Service.Serializer.Yaml;

public sealed class YamlSerializer : IObjectSerializer
{
    private static readonly ISerializer _serializer = new SerializerBuilder()
                                                   .WithNamingConvention(PascalCaseNamingConvention.Instance)
                                                   .Build();

    private static readonly IDeserializer _deserializer = new DeserializerBuilder()
                                                   .WithNamingConvention(PascalCaseNamingConvention.Instance)
                                                   .Build();

    public string Serialze<TObject>(TObject obj)
        where TObject : class
    {
        string result = _serializer.Serialize(obj);

        return result;
    }

    public IEnumerable<TObject> Deserialize<TObject>(string input)
        where TObject : class
    {
        IEnumerable<TObject> result = _deserializer.Deserialize<List<TObject>>(input);
        
        return result;
    }

    public TObject? DeserializeByKey<TObject>(string input, string key)
        where TObject : class
    {
        using StringReader reader = new StringReader(input);

        YamlStream documents = [];
        documents.Load(reader);

        int documentsLength = documents.Documents.Count;

        for (int index = 0; index < documentsLength; index++)
        {
            YamlMappingNode root = (YamlMappingNode)documents.Documents[index].RootNode;

            foreach (KeyValuePair<YamlNode, YamlNode> child in root.Children)
            {
                string? value = ((YamlScalarNode)child.Key).Value;

                if (value == key)
                    return _deserializer.Deserialize<TObject>(value);
            }
        }

        return null;
    }
}