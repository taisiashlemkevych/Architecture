namespace ScheduleSolid.Patterns.Composite;

public interface IScheduleComponent
{
    void Display(string indent = "");
}

public class ScheduleLesson : IScheduleComponent
{
    private readonly string subject;
    private readonly string time;

    public ScheduleLesson(string subject, string time)
    {
        this.subject = subject;
        this.time = time;
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}- {subject}, час: {time}");
    }
}

public class ScheduleGroup : IScheduleComponent
{
    private readonly string name;

    private readonly List<IScheduleComponent> components = new();

    public ScheduleGroup(string name)
    {
        this.name = name;
    }

    public void Add(IScheduleComponent component)
    {
        components.Add(component);
    }

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}{name}:");

        foreach (IScheduleComponent component in components)
        {
            component.Display(indent + "  ");
        }
    }
}