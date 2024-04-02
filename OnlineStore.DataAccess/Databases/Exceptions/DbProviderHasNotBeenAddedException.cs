namespace OnlineStore.DataAccess.Databases.Exceptions;

[Serializable]
public sealed class DbProviderHasNotBeenAddedException : Exception
{
    public DbProviderHasNotBeenAddedException() { }

    public DbProviderHasNotBeenAddedException(string message) : base(message) { }

    public DbProviderHasNotBeenAddedException(string message, Exception inner) : base(message, inner) { }

    protected DbProviderHasNotBeenAddedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}