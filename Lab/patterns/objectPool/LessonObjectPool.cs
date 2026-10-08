using ScheduleSolid.Models;
namespace ScheduleSolid.Patterns.ObjectPool;

public class LessonObjectPool
{
private readonly Stack<Lesson> availableLessons = new();

public Lesson GetLesson()
{
    if (availableLessons.Count > 0)
    {
        Console.WriteLine("[Object Pool] Отримано заняття з пулу.");
        return availableLessons.Pop();
    }

    Console.WriteLine("[Object Pool] Створено нове заняття.");

    return new Lesson(
        0,
        "Не вказано",
        "Не вказано",
        "Не вказано",
        new Teacher(0, "Не вказано"),
        new StudentGroup(0, "Не вказано"),
        new Classroom(0, 0)
    );
}

public void ReturnLesson(Lesson lesson)
{
    lesson.Id = 0;
    lesson.Subject = "Не вказано";
    lesson.Date = "Не вказано";
    lesson.Time = "Не вказано";

    lesson.Teacher = new Teacher(0, "Не вказано");
    lesson.Group = new StudentGroup(0, "Не вказано");
    lesson.Classroom = new Classroom(0, 0);

    availableLessons.Push(lesson);

    Console.WriteLine("[Object Pool] Заняття повернуто в пул.");
}
}
