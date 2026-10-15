namespace ScheduleSolid.Patterns.Bridge;

public interface IScheduleOutput
{
    void Output(string content);
}

public class ConsoleScheduleOutput : IScheduleOutput
{
    public void Output(string content)
    {
        Console.WriteLine(content);
    }
}

public class TextFileScheduleOutput : IScheduleOutput
{
    public void Output(string content)
    {
        File.WriteAllText("schedule-report.txt", content);
        Console.WriteLine("Звіт записано у файл schedule-report.txt");
    }
}

public class ScheduleReport
{
    private readonly IScheduleOutput output;

    public ScheduleReport(IScheduleOutput output)
    {
        this.output = output;
    }

    public void Generate(string schedule)
    {
        string report = $"ЗВІТ ПРО РОЗКЛАД ЗАНЯТЬ\n{schedule}";
        output.Output(report);
    }
}