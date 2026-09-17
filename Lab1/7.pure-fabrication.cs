//Без дотримання принципу Pure Fabrication
public class Schedule
{
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();

    public void SaveToDatabase()
    {

    }
}

//З дотриманням принципу Pure Fabrication
public class ScheduleRepository
{
    public void Save(Schedule schedule)
    {
        
    }
}