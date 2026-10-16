using ScheduleSolid.Patterns.Adapter;
using ScheduleSolid.Patterns.Bridge;

namespace ScheduleSolid;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========== ADAPTER ==========");

        ExternalScheduleService externalService = new();

        IScheduleReader reader = new ScheduleAdapter(externalService);

        string schedule = reader.ReadSchedule();
        Console.WriteLine(schedule);

        Console.WriteLine("\n========== BRIDGE ==========");

        ScheduleReport consoleReport =
            new(new ConsoleScheduleOutput());

        consoleReport.Generate(schedule);

        ScheduleReport fileReport =
            new(new TextFileScheduleOutput());

        fileReport.Generate(schedule);
    }
}