using Microsoft.Extensions.Configuration;

namespace OnlineStore.UI.Mvp.Configuration;

public interface IAppConfiguration
{
    IConfigurationRoot Root { get; internal set; }

    IAppConfiguration SetBasePath(string basePath);

    IAppConfiguration AddFile(string fileName, bool optional, bool reloadOnChange);

    IAppConfiguration AddEnviromentVariables();

    void Build();
}