using ScheduleSolid.Interfaces;

namespace ScheduleSolid.Services;

public class EmailNotificationService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine(
            $"[Email Notification] Надсилання email: {message}");
    }
}
