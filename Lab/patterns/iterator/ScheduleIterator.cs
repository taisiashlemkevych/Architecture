namespace ScheduleSolid.Patterns.Iterator;

public class ScheduleIterator
{
    private readonly List<string> lessons;

    private int position = 0;

    public ScheduleIterator(List<string> lessons)
    {
        this.lessons = lessons;
    }

    public bool HasNext()
    {
        return position < lessons.Count;
    }

    public string Next()
    {
        if (!HasNext())
        {
            throw new InvalidOperationException("Більше немає занять.");
        }

        return lessons[position++];
    }
}

public class Schedule
{
    private readonly List<string> lessons = new();

    public void AddLesson(string subject)
    {
        lessons.Add(subject);
    }

    public ScheduleIterator CreateIterator()
    {
        return new ScheduleIterator(lessons);
    }
}
