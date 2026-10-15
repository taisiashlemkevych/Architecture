using ScheduleSolid.Models;
using ScheduleSolid.Patterns.Builder;
using ScheduleSolid.Patterns.ObjectPool;
using ScheduleSolid.Patterns.Composite;
using ScheduleSolid.Patterns.Flyweight;

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

        Console.WriteLine($"Це той самий об'єкт: {ReferenceEquals(first, second)}");
        Console.WriteLine($"Предмет після очищення: {second.Subject}");

        Console.WriteLine("\nДемонстрацію завершено.");

        Console.WriteLine("\n========== COMPOSITE ==========");

        ScheduleGroup schedule = new("Розклад групи КН-21");

        ScheduleLesson lesson1 = new("Програмування", "10:00");
        ScheduleLesson lesson2 = new("Бази даних", "12:00");

        ScheduleGroup afternoon = new("Друга частина розкладу");
        afternoon.Add(new ScheduleLesson("Математика", "14:00"));

        schedule.Add(lesson1);
        schedule.Add(lesson2);
        schedule.Add(afternoon);

        schedule.Display();

        Console.WriteLine("\n========== FLYWEIGHT ==========");

        ClassroomFactory classroomFactory = new();

        ClassroomFlyweight room1 = classroomFactory.GetClassroom(101, 30);
        ClassroomFlyweight room2 = classroomFactory.GetClassroom(101, 30);

        room1.Display("Програмування", "10:00");
        room2.Display("Бази даних", "12:00");

        Console.WriteLine($"Аудиторія повторно використана: {ReferenceEquals(room1, room2)}");
    }
}
