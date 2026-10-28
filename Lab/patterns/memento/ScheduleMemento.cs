namespace ScheduleSolid.Patterns.Memento;

public class ScheduleMemento
{
    public string Lesson { get; }

    public ScheduleMemento(string lesson)
    {
        Lesson = lesson;
    }
}

public class MementoSchedule
{
    public string Lesson { get; private set; }

    public MementoSchedule(string lesson)
    {
        Lesson = lesson;
    }

    public void ChangeLesson(string lesson)
    {
        Lesson = lesson;
    }

    public ScheduleMemento Save()
    {
        return new ScheduleMemento(Lesson);
    }

    public void Restore(ScheduleMemento memento)
    {
        Lesson = memento.Lesson;
    }

    public void Display()
    {
        Console.WriteLine($"Поточне заняття: {Lesson}");
    }
}
