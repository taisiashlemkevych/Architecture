// Без дотримання принципу Creator
public class Program
{
    public void CreateData()
    {
        Schedule schedule = new Schedule();
        Lesson lesson = new Lesson { Name = "Бізнес-аналіз" }; 
        schedule.Lessons.Add(lesson);
    }
}

// З дотриманням принципу Creator
public class Schedule
{
    private List<Lesson> _lessons = new List<Lesson>();

    public void AddLesson(string name, DateTime start, DateTime end)
    {
        Lesson newLesson = new Lesson { Name = name, StartTime = start, EndTime = end };
        _lessons.Add(newLesson);
    }
}
