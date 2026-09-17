// Без дотримання принципу High Cohesion (Висока зв’язність)
public class Schedule
{
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    public void ExportToPdf() 
    {
        // Логіка малювання таблиць для PDF...
    }
}

// З дотриманням принципу High Cohesion (Висока зв’язність)
public class Schedule
{
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
}

public class ScheduleExporter
{
    public void ExportToPdf(Schedule schedule)
    {
        // Логіка малювання таблиць для PDF...
    }
}
