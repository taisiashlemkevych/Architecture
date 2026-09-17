//Без дотримання принципу Controller
public class ScheduleUIForm
{
    public void OnAddLessonButtonClicked(string name)
    {
        var dbContext = new DatabaseContext();
        dbContext.Lessons.Add(new Lesson { Name = name });
        dbContext.SaveChanges();
    }
}

//З дотриманням Controller
public class ScheduleController
{
    private readonly ScheduleService _scheduleService;
    
    public void AddLesson(string name)
    {
        _scheduleService.CreateLesson(name);
    }
}