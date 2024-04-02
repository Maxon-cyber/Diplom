using Microsoft.Extensions.Configuration;

namespace OnlineStore.UI.Mvp.Configuration.Microsoft;

public sealed class MicrosoftConfiguration : IAppConfiguration
{
    private readonly IConfigurationBuilder _configurationBuilder;

    public IConfigurationRoot Root { get; set; }

    public MicrosoftConfiguration()
        => _configurationBuilder = new ConfigurationManager();

    public IAppConfiguration SetBasePath(string basePath)
    {
        _configurationBuilder.SetBasePath(basePath);
        return this;
    }

    public IAppConfiguration AddFile(string fileName, bool optional, bool reloadOnChange)
    {
        switch (Path.GetExtension(fileName))
        {
            case ".yml":
                _configurationBuilder.AddYamlFile(fileName, optional, reloadOnChange);
                break;
            default:
                throw new ArgumentException($"Провайдер конфигурации для файла {fileName} не найден");
        }

        return this;
    }

    public IAppConfiguration AddEnviromentVariables()
    {
        _configurationBuilder.AddEnvironmentVariables();
        return this;
    }

    public void Build()
        => Root = _configurationBuilder.Build();
}