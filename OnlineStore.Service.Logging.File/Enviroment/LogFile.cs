namespace OnlineStore.Service.Caching.Enviroment;

public sealed class LogFile
{
    private readonly string SEPARATOR = new string('-', 70);
    
    public string Name { get; internal set; }

    public string FullName { get; internal set; }

    public long Size { get; internal set; }

    public long SizeLimit { get; } = 1024;

    public string Extension { get; internal set; }

    public DateTime LastAccessTime { get; internal set; }

    public DateTime LastWriteTime { get; internal set; }

    internal LogFile() { }

    internal async Task<string> ReadAsync()
    {
        string[] lines = await File.ReadAllLinesAsync(FullName);

        string result = string.Empty;

        foreach (string line in lines)
            if (line != SEPARATOR)
                result += line;

        return result;
    }

    internal async Task WriteAsync(string content)
    {
        if (Size >= SizeLimit)
            while (Size != SizeLimit / 2)
            {
                string[] lines = await File.ReadAllLinesAsync(FullName);

                await File.WriteAllLinesAsync(FullName, lines.SkipWhile(line => line != SEPARATOR));
            }

        await File.AppendAllTextAsync(FullName, SEPARATOR);
        await File.AppendAllTextAsync(FullName, content);
    }

    internal async Task ClearAsync()
        => await File.WriteAllTextAsync(FullName, string.Empty);
}