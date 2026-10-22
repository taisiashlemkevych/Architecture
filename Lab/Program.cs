using ScheduleSolid.Patterns.Adapter;
using ScheduleSolid.Patterns.Bridge;
using ScheduleSolid.Patterns.Composite;
using ScheduleSolid.Patterns.Flyweight;
using ScheduleSolid.Patterns.Decorator;
using ScheduleSolid.Patterns.Proxy;

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


        Console.WriteLine("\n========== COMPOSITE ==========");

        ScheduleGroup scheduleGroup = new("Розклад групи КН-21");

        scheduleGroup.Add(
            new ScheduleLesson("Програмування", "10:00"));

        scheduleGroup.Add(
            new ScheduleLesson("Бази даних", "12:00"));

        ScheduleGroup afternoonGroup =
            new("Друга частина розкладу");

        afternoonGroup.Add(
            new ScheduleLesson("Математика", "14:00"));

        scheduleGroup.Add(afternoonGroup);

        scheduleGroup.Display();


        Console.WriteLine("\n========== FLYWEIGHT ==========");

        ClassroomFactory classroomFactory = new();

        ClassroomFlyweight room1 =
            classroomFactory.GetClassroom(101, 30);

        ClassroomFlyweight room2 =
            classroomFactory.GetClassroom(101, 30);

        room1.Display("Програмування", "10:00");
        room2.Display("Бази даних", "12:00");

        Console.WriteLine(
            $"Аудиторія повторно використана: " +
            $"{ReferenceEquals(room1, room2)}");

        Console.WriteLine("\nДемонстрацію завершено.");

        Console.WriteLine("\n========== DECORATOR ==========");

        IScheduleInfo scheduleInfo = new BasicSchedule();

        scheduleInfo = new TeacherScheduleDecorator(scheduleInfo);

        scheduleInfo = new ClassroomScheduleDecorator(scheduleInfo);

        Console.WriteLine(scheduleInfo.GetInfo());

        Console.WriteLine("\n========== PROXY ==========");

        IScheduleService realService = new RealScheduleService();

        IScheduleService allowedProxy =
        new ScheduleProxy(realService, true);

        Console.WriteLine(allowedProxy.GetSchedule());

        IScheduleService deniedProxy =
        new ScheduleProxy(realService, false);

        Console.WriteLine(deniedProxy.GetSchedule());
    }
}