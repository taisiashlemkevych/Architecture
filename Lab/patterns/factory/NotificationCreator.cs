using ScheduleSolid.Interfaces;
using ScheduleSolid.Services;

namespace ScheduleSolid.Patterns.factory;

public abstract class NotificationCreator
{
    public abstract INotificationService CreateNotificationService();

    public void NotifyUser(string message)
    {
        var service = CreateNotificationService();
        service.Send(message);
    }
}

public class ConsoleNotificationCreator : NotificationCreator
{
    public override INotificationService CreateNotificationService()
    {
        Console.WriteLine("[Factory Method] Створення ConsoleNotificationService");
        return new ConsoleNotificationService();
    }
}

public class EmailNotificationCreator : NotificationCreator
{
    public override INotificationService CreateNotificationService()
    {
        Console.WriteLine("[Factory Method] Створення EmailNotificationService");
        return new EmailNotificationService();
    }
}
