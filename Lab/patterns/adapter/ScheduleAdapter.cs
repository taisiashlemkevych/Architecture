namespace ScheduleSolid.Patterns.Adapter;

public interface IScheduleReader
{
    string ReadSchedule();
}

public class ExternalScheduleService
{
    public string GetScheduleData()
    {
        return "Програмування — 10:00, аудиторія 101";
    }
}

public class ScheduleAdapter : IScheduleReader
{
    private readonly ExternalScheduleService service;

    public ScheduleAdapter(ExternalScheduleService service)
    {
        this.service = service;
    }

    public string ReadSchedule()
    {
        return service.GetScheduleData();
    }
}
