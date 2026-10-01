using ScheduleSolid.Interfaces;

namespace ScheduleSolid.Services;

public class ConsoleNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine(
            $"[Console Notification] {message}");
    }
}