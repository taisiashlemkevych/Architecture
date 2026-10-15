namespace ScheduleSolid.Patterns.Adapter;

// Інтерфейс, через який програма отримує розклад.
public interface IScheduleReader
{
    string ReadSchedule();
}

// Імітація старого сервісу з несумісним методом.
public class ExternalScheduleService
{
    public string GetScheduleData()
    {
        return "Програмування — 10:00, аудиторія 101";
    }
}

// Адаптер узгоджує старий сервіс із потрібним інтерфейсом.
public class ScheduleAdapter : IScheduleReader
{
    private readonly ExternalScheduleService service;

    public ScheduleAdapter(ExternalScheduleService service)
    {
        this.service = service;
    }

    // Викликаємо метод старого сервісу через потрібний інтерфейс.
    public string ReadSchedule()
    {
        return service.GetScheduleData();
    }
}
