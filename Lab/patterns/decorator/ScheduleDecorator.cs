namespace ScheduleSolid.Patterns.Decorator;

public interface IScheduleInfo
{
    string GetInfo();
}

public class BasicSchedule : IScheduleInfo
{
    public string GetInfo()
    {
        return "Програмування — 10:00";
    }
}

public class ScheduleDecorator : IScheduleInfo
{
    protected readonly IScheduleInfo schedule;

    public ScheduleDecorator(IScheduleInfo schedule)
    {
        this.schedule = schedule;
    }

    public virtual string GetInfo()
    {
        return schedule.GetInfo();
    }
}

public class TeacherScheduleDecorator : ScheduleDecorator
{
    public TeacherScheduleDecorator(IScheduleInfo schedule)
        : base(schedule)
    {
    }

    public override string GetInfo()
    {
        return schedule.GetInfo() + "\nВикладач: Іваненко Іван";
    }
}

public class ClassroomScheduleDecorator : ScheduleDecorator
{
    public ClassroomScheduleDecorator(IScheduleInfo schedule)
        : base(schedule)
    {
    }

    public override string GetInfo()
    {
        return schedule.GetInfo() + "\nАудиторія: 101";
    }
}