namespace ScheduleSolid.Patterns.Visitor;

public interface IScheduleElement
{
    void Accept(IScheduleVisitor visitor);
}

public interface IScheduleVisitor
{
    void Visit(Lecture lecture);
    void Visit(Practice practice);
}

public class Lecture : IScheduleElement
{
    public string Subject { get; }
    public string Time { get; }

    public Lecture(string subject, string time)
    {
        Subject = subject;
        Time = time;
    }

    public void Accept(IScheduleVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Practice : IScheduleElement
{
    public string Subject { get; }
    public string Time { get; }

    public Practice(string subject, string time)
    {
        Subject = subject;
        Time = time;
    }

    public void Accept(IScheduleVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class ScheduleInfoVisitor : IScheduleVisitor
{
    public void Visit(Lecture lecture)
    {
        Console.WriteLine(
            $"Лекція: {lecture.Subject}, час: {lecture.Time}");
    }

    public void Visit(Practice practice)
    {
        Console.WriteLine(
            $"Практика: {practice.Subject}, час: {practice.Time}");
    }
}

public class ScheduleCountVisitor : IScheduleVisitor
{
    public int Count { get; private set; }

    public void Visit(Lecture lecture)
    {
        Count++;
    }

    public void Visit(Practice practice)
    {
        Count++;
    }
}
