namespace ScheduleSolid.Patterns.Command;

public interface IScheduleCommand
{
    void Execute();
}

public class ScheduleManager
{
    private readonly List<string> lessons = new();

    public void AddLesson(string subject)
    {
        lessons.Add(subject);
        Console.WriteLine($"Додано заняття: {subject}");
    }

    public void RemoveLesson(string subject)
    {
        if (lessons.Remove(subject))
        {
            Console.WriteLine($"Видалено заняття: {subject}");
        }
        else
        {
            Console.WriteLine($"Заняття не знайдено: {subject}");
        }
    }

    public void ShowLessons()
    {
        Console.WriteLine("Заняття в розкладі:");

        foreach (string lesson in lessons)
        {
            Console.WriteLine($"- {lesson}");
        }
    }
}

public class AddLessonCommand : IScheduleCommand
{
    private readonly ScheduleManager manager;
    private readonly string subject;

    public AddLessonCommand(ScheduleManager manager, string subject)
    {
        this.manager = manager;
        this.subject = subject;
    }

    public void Execute()
    {
        manager.AddLesson(subject);
    }
}

public class RemoveLessonCommand : IScheduleCommand
{
    private readonly ScheduleManager manager;
    private readonly string subject;

    public RemoveLessonCommand(ScheduleManager manager, string subject)
    {
        this.manager = manager;
        this.subject = subject;
    }

    public void Execute()
    {
        manager.RemoveLesson(subject);
    }
}