namespace ScheduleSolid.Patterns.Mediator;

public interface IScheduleMediator
{
    void Notify(object sender, string message);
}

public class ScheduleMediator : IScheduleMediator
{
    private readonly List<MediatorStudent> students = new();

    public void RegisterStudent(MediatorStudent student)
    {
        students.Add(student);
    }

    public void Notify(object sender, string message)
    {
        foreach (MediatorStudent student in students)
        {
            student.ReceiveMessage(message);
        }
    }
}

public class Teacher
{
    private readonly IScheduleMediator mediator;

    public Teacher(IScheduleMediator mediator)
    {
        this.mediator = mediator;
    }

    public void ChangeSchedule(string message)
    {
        Console.WriteLine($"Викладач повідомляє: {message}");
        mediator.Notify(this, message);
    }
}

public class MediatorStudent
{
    public string Name { get; }

    public MediatorStudent(string name)
    {
        Name = name;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} отримує повідомлення: {message}");
    }
}
