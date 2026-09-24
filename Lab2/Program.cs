using ScheduleSolid.Interfaces;
using ScheduleSolid.Models;
using ScheduleSolid.Services;

namespace ScheduleSolid;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========================================");
        Console.WriteLine("   СИСТЕМА РОЗКЛАДУ НАВЧАЛЬНИХ ЗАНЯТЬ");
        Console.WriteLine("   Демонстрація принципів SOLID");
        Console.WriteLine("========================================");

        Teacher teacher1 = new Teacher(
            1,
            "Іваненко Іван Іванович");

        Teacher teacher2 = new Teacher(
            2,
            "Петренко Олена Олександрівна");

        StudentGroup group1 = new StudentGroup(
            1,
            "КН-21");

        StudentGroup group2 = new StudentGroup(
            2,
            "КН-22");

        Classroom classroom1 = new Classroom(
            101,
            30);

        Classroom classroom2 = new Classroom(
            205,
            25);

        Lesson lesson1 = new Lesson(
            1,
            "Програмування",
            "23.09.2026",
            "10:00",
            teacher1,
            group1,
            classroom1);

        Lesson lesson2 = new Lesson(
            2,
            "Бази даних",
            "23.09.2026",
            "12:00",
            teacher2,
            group2,
            classroom2);

        Console.WriteLine("\n========== SRP ==========");

        Console.WriteLine(
            "Schedule відповідає за зберігання розкладу.");

        Console.WriteLine(
            "ScheduleValidator відповідає за перевірку розкладу.");

        Console.WriteLine(
            "NotificationService відповідає за повідомлення.");

        Console.WriteLine("\n========== DIP ==========");

        Schedule schedule = new Schedule();

        ScheduleValidator validator = new ScheduleValidator();

        INotificationService notificationService =
            new ConsoleNotificationService();

        ScheduleManager manager = new ScheduleManager(
            schedule,
            validator,
            notificationService);

        Console.WriteLine(
            "ScheduleManager залежить від абстракції " +
            "INotificationService.");


        Console.WriteLine("\n========== ДОДАВАННЯ ЗАНЯТЬ ==========");

        manager.AddLesson(lesson1);
        manager.AddLesson(lesson2);

        manager.ReadSchedule();

        Console.WriteLine("\n========== LSP ==========");

        INotificationService consoleService =
            new ConsoleNotificationService();

        INotificationService emailService =
            new EmailNotificationService();

        consoleService.Send(
            "Повідомлення через ConsoleNotificationService.");

        emailService.Send(
            "Повідомлення через EmailNotificationService.");

        Console.WriteLine(
            "Обидві реалізації можуть замінити " +
            "INotificationService.");

        Console.WriteLine("\n========== OCP ==========");

        Console.WriteLine(
            "Додаємо новий тип повідомлень " +
            "без зміни ScheduleManager.");

        INotificationService newNotificationService =
            new EmailNotificationService();

        ScheduleManager emailManager = new ScheduleManager(
            schedule,
            validator,
            newNotificationService);

        emailManager.RemoveLesson(2);

        Console.WriteLine("\n========== ISP ==========");

        IScheduleReader reader = manager;

        IScheduleWriter writer = manager;

        reader.ReadSchedule();

        Console.WriteLine(
            "ScheduleManager реалізує окремі інтерфейси " +
            "IScheduleReader та IScheduleWriter.");


        Console.WriteLine("\n========== REPORT ==========");

        IReportGenerator reportGenerator =
            new PdfReportGenerator();

        reportGenerator.GenerateReport();

        Console.WriteLine("\n========== ПЕРЕВІРКА КОНФЛІКТУ ==========");

        Lesson conflictingLesson = new Lesson(
            3,
            "Математика",
            "23.09.2026",
            "10:00",
            teacher1,
            group1,
            classroom1);

        manager.AddLesson(conflictingLesson);

        Console.WriteLine("\n========================================");
        Console.WriteLine("Демонстрацію SOLID завершено.");
        Console.WriteLine("========================================");
    }
}