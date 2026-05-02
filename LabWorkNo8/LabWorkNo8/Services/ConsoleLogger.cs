// Services/ConsoleLogger.cs

using LabWorkNo8.Interfaces;

namespace LabWorkNo8.Services;

public sealed class ConsoleLogger : ILogger
{
    private static readonly Lazy<ConsoleLogger> _instance = 
        new Lazy<ConsoleLogger>(() => new ConsoleLogger());

    public static ConsoleLogger Instance => _instance.Value;

    private ConsoleLogger() { }

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] LOG: {message}");
    }
}
