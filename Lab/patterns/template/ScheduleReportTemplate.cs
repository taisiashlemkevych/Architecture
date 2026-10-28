namespace ScheduleSolid.Patterns.Template;

public abstract class ScheduleReportTemplate
{
    public void GenerateReport()
    {
        LoadSchedule();
        FormatReport();
        SaveReport();
    }

    protected virtual void LoadSchedule()
    {
        Console.WriteLine("Завантаження розкладу.");
    }

    protected abstract void FormatReport();

    protected virtual void SaveReport()
    {
        Console.WriteLine("Збереження звіту.");
    }
}

public class TextScheduleReport : ScheduleReportTemplate
{
    protected override void FormatReport()
    {
        Console.WriteLine("Форматування звіту у вигляді звичайного тексту.");
    }
}

public class DetailedScheduleReport : ScheduleReportTemplate
{
    protected override void FormatReport()
    {
        Console.WriteLine("Форматування детального звіту з предметами та часом.");
    }
}
