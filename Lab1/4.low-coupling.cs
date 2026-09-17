// Без дотримання принципу Low Coupling 
public class ScheduleManager
{
    private SmsSender _smsSender = new SmsSender(); 

    public void CancelLesson(Lesson lesson)
    {
        _smsSender.Send($"Заняття {lesson.Name} скасовано.");
    }
}

//З дотриманням Low Coupling 
public interface INotifier { void Send(string message); }

public class ScheduleManager
{
    private readonly INotifier _notifier;

    public ScheduleManager(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void CancelLesson(Lesson lesson)
    {
        _notifier.Send($"Заняття {lesson.Name} скасовано.");
    }
}