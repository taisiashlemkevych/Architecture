using ScheduleSolid.Models;
using ScheduleSolid.Patterns.Builder;
using ScheduleSolid.Patterns.ObjectPool;
namespace ScheduleSolid;

public class Program
{
public static void Main()
{
Console.OutputEncoding = System.Text.Encoding.UTF8;

    Console.WriteLine("========== BUILDER ==========");

    Teacher teacher = new(1, "Іваненко Іван");
    StudentGroup group = new(1, "КН-21");
    Classroom classroom = new(101, 30);

    Lesson lesson = new LessonBuilder()
        .SetId(1)
        .SetSubject("Програмування")
        .SetDate("08.10.2026")
        .SetTime("10:00")
        .SetTeacher(teacher)
        .SetGroup(group)
        .SetClassroom(classroom)
        .Build();

    lesson.DisplayInfo();

    Console.WriteLine("\n========== OBJECT POOL ==========");

    LessonObjectPool pool = new();

    Lesson first = pool.GetLesson();

    first.Id = 2;
    first.Subject = "Бази даних";
    first.Date = "08.10.2026";
    first.Time = "12:00";
    first.Teacher = new Teacher(2, "Петренко Олена");
    first.Group = new StudentGroup(2, "КН-22");
    first.Classroom = new Classroom(202, 25);

    first.DisplayInfo();

    pool.ReturnLesson(first);

    Lesson second = pool.GetLesson();

    Console.WriteLine(
        $"Це той самий об'єкт: {ReferenceEquals(first, second)}");

    Console.WriteLine(
        $"Предмет після очищення: {second.Subject}");

    Console.WriteLine("\nДемонстрацію завершено.");
}
}
