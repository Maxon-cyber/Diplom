namespace OnlineStore.Service.Logging;

public interface ILogger
{
    void LogInfo();

    void LogMessage();

    void LogError();
}