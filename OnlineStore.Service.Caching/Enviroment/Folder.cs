namespace OnlineStore.Service.Caching.Enviroment;

public sealed class Folder
{
    private readonly List<FileCache> _files = [];

    public string Name { get; }

    public string FullName { get; }

    public int CountOfFiles { get; }

    public DateTime LastAccessTime { get; }

    public DateTime LastWriteTime { get; }

    internal Folder(string path)
    {
        DirectoryInfo directory = new DirectoryInfo(path);

        Name = directory.Name;
        FullName = directory.FullName;
        LastAccessTime = directory.LastAccessTime;
        LastWriteTime = directory.LastWriteTime;

        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files)
            _files.Add(new FileCache()
            {
                Name = Path.GetFileNameWithoutExtension(file.Name),
                FullName = file.FullName,
                Size = file.Length,
                Extension = file.Extension,
                LastAccessTime = file.LastAccessTime,
                LastWriteTime = file.LastWriteTime
            });

        CountOfFiles = _files.Count;
    }

    public FileCache? this[string fileName]
    {
        get
        {
            foreach (FileCache fileCache in _files)
                if (string.Equals(fileCache.Name, fileName, StringComparison.CurrentCultureIgnoreCase))
                    return fileCache;

            return null;
        }
    }
}