namespace ScheduleSolid.Patterns.Bridge;

// Інтерфейс визначає спосіб виведення звіту.
public interface IScheduleOutput
{
    void Output(string content);
}

// Виведення розкладу в консоль.
public class ConsoleScheduleOutput : IScheduleOutput
{
    public void Output(string content)
    {
        Console.WriteLine(content);
    }
}

// Запис розкладу в текстовий файл.
public class TextFileScheduleOutput : IScheduleOutput
{
    public void Output(string content)
    {
        File.WriteAllText("schedule-report.txt", content);
        Console.WriteLine("Звіт записано у файл schedule-report.txt");
    }
}

// Формує звіт і передає його обраному способу виведення.
public class ScheduleReport
{
    private readonly IScheduleOutput output;

    public ScheduleReport(IScheduleOutput output)
    {
        this.output = output;
    }

    // Формуємо звіт незалежно від способу його виведення.
    public void Generate(string schedule)
    {
        string report = $"ЗВІТ ПРО РОЗКЛАД ЗАНЯТЬ\n{schedule}";
        output.Output(report);
    }
}