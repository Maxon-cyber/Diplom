namespace OnlineStore.DataAccess.Providers.SqlServer.Models;

public sealed class DatabaseParameters()
{
    public string Server { get; set; }

    public int Port { get; set; }

    public string Database { get; set; }

    public bool IntegratedSecurity { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool TrustedConnection { get; set; }

    public bool TrustServerCertificate { get; set; }

    public TimeSpan? ConnectionTimeout { get; set; }

    public int? MaxPoolSize { get; set; }
}