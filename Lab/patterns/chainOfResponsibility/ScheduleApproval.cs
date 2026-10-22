namespace ScheduleSolid.Patterns.ChainOfResponsibility;

public abstract class ScheduleHandler
{
    protected ScheduleHandler? nextHandler;

    public ScheduleHandler SetNext(ScheduleHandler handler)
    {
        nextHandler = handler;
        return handler;
    }

    public abstract bool Handle(string subject);
}

public class SubjectHandler : ScheduleHandler
{
    public override bool Handle(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
        {
            Console.WriteLine("Помилка: назву заняття не вказано.");
            return false;
        }

        Console.WriteLine("Перевірку назви пройдено.");
        return nextHandler?.Handle(subject) ?? true;
    }
}

public class ApprovalHandler : ScheduleHandler
{
    public override bool Handle(string subject)
    {
        if (subject.Contains("Заборонено",
                StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Додавання заняття заборонено.");
            return false;
        }

        Console.WriteLine("Запит погоджено.");
        return nextHandler?.Handle(subject) ?? true;
    }
}