// Без дотримання принципу Information Expert
public class Lesson
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

public class DurationCalculator
{
    public TimeSpan CalculateDuration(Lesson lesson)
    {
        return lesson.EndTime - lesson.StartTime;
    }
}

// З дотриманням принципу Information Expert
public class Lesson
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public TimeSpan GetDuration()
    {
        return EndTime - StartTime;
    }
}

