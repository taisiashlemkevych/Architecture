using ScheduleSolid.Interfaces;

namespace ScheduleSolid.Patterns.abstractFactory;

public interface IUniversityInfrastructureFactory
{
    INotificationService CreateNotification();
    IReportGenerator CreateReport();
}

public class OfflineInfrastructureFactory : IUniversityInfrastructureFactory
{
    public INotificationService CreateNotification()
    {
        Console.WriteLine("[Abstract Factory] Офлайн інфраструктура створює Console Notification");
        return new Services.ConsoleNotificationService();
    }

    public IReportGenerator CreateReport()
    {
        Console.WriteLine("[Abstract Factory] Офлайн інфраструктура створює PDF Report");
        return new Services.PdfReportGenerator();
    }
}

public class OnlineInfrastructureFactory : IUniversityInfrastructureFactory
{
    public INotificationService CreateNotification()
    {
        Console.WriteLine("[Abstract Factory] Онлайн інфраструктура створює Email Notification");
        return new Services.EmailNotificationService();
    }

    public IReportGenerator CreateReport()
    {
        Console.WriteLine("[Abstract Factory] Онлайн інфраструктура створює HTML Report");
        return new Services.HtmlReportGenerator();
    }
}
