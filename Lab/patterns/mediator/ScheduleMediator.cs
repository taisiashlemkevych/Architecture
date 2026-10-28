namespace ScheduleSolid.Patterns.Mediator;

public interface IScheduleMediator
{
    void Notify(object sender, string message);
}

public class ScheduleMediator : IScheduleMediator
{
    private readonly List<Student> students = new();

    public void RegisterStudent(Student student)
    {
        students.Add(student);
    }

    public void Notify(object sender, string message)
    {
  
        foreach (Student student in students)
        {
            if (!ReferenceEquals(sender, student))
            {
                student.ReceiveMessage(message);
            }
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

public class Student
{
    public string Name { get; }

    public Student(string name)
    {
        Name = name;
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} отримує повідомлення: {message}");
    }
}
