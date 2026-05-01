// ConsoleNotificationSender.cs

using LabWorkNo7.Interfaces;

namespace LabWorkNo7.Services;

public class ConsoleNotificationSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine($"[NOTIFICATION]: {message}");
    }
}
