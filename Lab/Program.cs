using ScheduleSolid.Interfaces;
using ScheduleSolid.Models;
using ScheduleSolid.Services;
using ScheduleSolid.Patterns;
using ScheduleSolid.Patterns.factory;
using ScheduleSolid.Patterns.abstractFactory;
using ScheduleSolid.Patterns.singletonPrototype;


namespace ScheduleSolid;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding =
            System.Text.Encoding.UTF8;
        Console.WriteLine("=================================");
        Console.WriteLine("ЛАБОРАТОРНА РОБОТА №4: Factory Method & Abstract Factory");
        Console.WriteLine("=================================\n");

        Console.WriteLine("--- Factory Method ---");
        NotificationCreator creator = new EmailNotificationCreator();
        creator.NotifyUser("Увага! Зміни в розкладі на завтра.");

        Console.WriteLine("\n--- Abstract Factory ---");
        IUniversityInfrastructureFactory factory = new OnlineInfrastructureFactory();
        var notification = factory.CreateNotification();
        var report = factory.CreateReport();
        
        notification.Send("Запрошення на онлайн-лекцію");
        report.GenerateReport();

        Console.WriteLine("=================================");
        Console.WriteLine("ЛАБОРАТОРНА РОБОТА №3");
        Console.WriteLine("Singleton + Prototype");
        Console.WriteLine("Тема: Розклад навчальних занять");
        Console.WriteLine("=================================");

        Console.WriteLine("\n========== SINGLETON ==========");

        ScheduleConfiguration config1 =
            ScheduleConfiguration.Instance;

        ScheduleConfiguration config2 =
            ScheduleConfiguration.Instance;

        config1.DisplayConfiguration();

        Console.WriteLine(
            $"\nconfig1 == config2: {config1 == config2}");

        config1.UniversityName =
            "Національний університет";

        Console.WriteLine(
            $"config2 бачить: {config2.UniversityName}");


        Console.WriteLine("\n========== PROTOTYPE ==========");

        Teacher teacher = new Teacher(
            1,
            "Іваненко Іван Іванович");

        StudentGroup group = new StudentGroup(
            1,
            "КН-21");

        Classroom classroom = new Classroom(
            101,
            30);

        Lesson originalLesson = new Lesson(
            1,
            "Програмування",
            "05.10.2026",
            "10:00",
            teacher,
            group,
            classroom);

        Console.WriteLine("\nОригінальне заняття:");
        originalLesson.DisplayInfo();

        LessonPrototype prototype =
            new LessonPrototype(originalLesson);

        Lesson clonedLesson =
            prototype.Clone();

        clonedLesson.Id = 2;
        clonedLesson.Group.Name = "КН-22";
        clonedLesson.Date = "06.10.2026";

        Console.WriteLine("\nСкопійоване заняття:");
        clonedLesson.DisplayInfo();

        Console.WriteLine(
            "\noriginalLesson == clonedLesson: " +
            $"{ReferenceEquals(originalLesson, clonedLesson)}");

        Console.WriteLine(
            "Prototype створив окремий об'єкт.");


        Console.WriteLine("\n========== РОЗКЛАД ==========");

        Schedule schedule = new Schedule();

        schedule.AddLesson(originalLesson);
        schedule.AddLesson(clonedLesson);

        schedule.DisplayLessons();

        Console.WriteLine("\n=================================");
        Console.WriteLine("Демонстрацію завершено.");
        Console.WriteLine("=================================");
    }
}