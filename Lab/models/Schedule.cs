namespace ScheduleSolid.Models;

public class Schedule
{
    private readonly List<Lesson> lessons = new();

    public IReadOnlyList<Lesson> Lessons => lessons;

    public void AddLesson(Lesson lesson)
    {
        lessons.Add(lesson);

        Console.WriteLine(
            $"Заняття '{lesson.Subject}' додано до розкладу.");
    }

    public void RemoveLesson(int lessonId)
    {
        Lesson? lesson = lessons.FirstOrDefault(x => x.Id == lessonId);

        if (lesson != null)
        {
            lessons.Remove(lesson);

            Console.WriteLine(
                $"Заняття '{lesson.Subject}' видалено з розкладу.");
        }
        else
        {
            Console.WriteLine(
                $"Заняття з ID {lessonId} не знайдено.");
        }
    }
    
    public void DisplayLessons()
    {
        Console.WriteLine("\nПоточний розклад:");

        foreach (Lesson lesson in lessons)
        {
            lesson.DisplayInfo();
        }
    }
}