namespace ScheduleSolid.Patterns.Proxy;

public interface IScheduleService
{
    string GetSchedule();
}

public class RealScheduleService : IScheduleService
{
    public string GetSchedule()
    {
        return "Програмування — 10:00, аудиторія 101";
    }
}

public class ScheduleProxy : IScheduleService
{
    private readonly IScheduleService realService;
    private readonly bool hasAccess;

    public ScheduleProxy(IScheduleService realService, bool hasAccess)
    {
        this.realService = realService;
        this.hasAccess = hasAccess;
    }

    public string GetSchedule()
    {
        if (!hasAccess)
        {
            return "Доступ до розкладу заборонено.";
        }

        Console.WriteLine("Доступ дозволено.");
        return realService.GetSchedule();
    }
}