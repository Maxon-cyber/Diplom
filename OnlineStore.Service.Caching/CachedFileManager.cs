using OnlineStore.Service.Caching.Enviroment;
using OnlineStore.Service.Caching_Abstractions;
using OnlineStore.Service.Serializer.Abstractions;
using System.Reflection;

namespace OnlineStore.Service.Caching;

public sealed class CachedFileManager<TObject>(string path) : ICache<TObject>
{
    private readonly IObjectSerializer _serializer;

    public Folder Folder { get; } = new Folder(path);

    public async Task<IEnumerable<TObject>> ReadAsync(string fileName)
    {
        FileCache file = Folder[fileName.ToLower()] ?? throw new FileNotFoundException($"Файл {fileName} не найден");

        IEnumerable<TObject> result = _serializer.Deserialize<TObject>(await file.ReadAsync());

        return result;
    }

    public async Task<IEnumerable<TObject>> ReadByAsync(string fileName, TObject parameter)
    {
        List<TObject> listOfEntities = [];

        IEnumerable<TObject> entities = await ReadAsync(fileName);

        foreach (TObject entity in entities)
        {
            bool isMatch = false;

            foreach (PropertyInfo property in typeof(TObject).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead)
                {
                    object? parameterValue = property.GetValue(parameter);
                    object? entityValue = property.GetValue(entity);

                    if (parameterValue != null && parameterValue.Equals(entityValue))
                    {
                        isMatch = true;
                        break;
                    }
                }
            }

            if (isMatch)
                listOfEntities.Add(entity);
        }

        return listOfEntities;
    }

    public async Task<string> WriteAsync(string fileName, TObject parameter)
    {
        FileCache file = Folder[fileName.ToLower()] ?? throw new FileNotFoundException($"Файл {fileName} не найден");

        string result = _serializer.Serialze(parameter);

        await file.WriteAsync(result);

        return result;
    }

    public async Task<string> WriteAsync(string fileName, ICollection<TObject> parameter)
    {
        FileCache file = Folder[fileName.ToLower()] ?? throw new FileNotFoundException($"Файл {fileName} не найден");

        string result = _serializer.Serialze(parameter);

        await file.WriteAsync(result);

        return result;
    }

    public async Task<bool> ContainsAsync(string fileName, TObject parameter)
    {
        FileCache file = Folder[fileName.ToLower()] ?? throw new FileNotFoundException($"Файл {fileName} не найден");

        if (await file.ReadAsync() == null)
            return false;

        IEnumerable<TObject> data = await ReadByAsync(file.Name, parameter);

        return data.Any();
    }

    public async Task ClearAsync(string fileName)
    {
        FileCache file = Folder[fileName.ToLower()] ?? throw new FileNotFoundException($"Файл {fileName} не найден");

        await file.ClearAsync();
    }
}