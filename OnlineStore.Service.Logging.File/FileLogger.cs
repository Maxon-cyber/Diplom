using System.Drawing;

namespace OnlineStore.Service.Logging.File;

public sealed class FileLogger //: ILogger
{
    private readonly string _filePath;

    private readonly Color INFO_COLOR = Color.Green;
    private readonly Color WARNING_COLOR = Color.Yellow;
    private readonly Color ERROR_COLOR = Color.Red;

    private const string MESSAGE_PATTERN = "DATE [ERROR_LEVEL]: MESSAGE";

    public void LogInfo(string message)
    {

    }

    public void LogError()
    {
        throw new NotImplementedException();
    }

    public void LogMessage()
    {
        throw new NotImplementedException();
    }
}