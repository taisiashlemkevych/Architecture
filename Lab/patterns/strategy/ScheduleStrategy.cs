namespace ScheduleSolid.Patterns.Strategy;

public class StrategyLesson
{
    public string Subject { get; }
    public string Time { get; }

    public StrategyLesson(string subject, string time)
    {
        Subject = subject;
        Time = time;
    }

    public override string ToString()
    {
        return $"{Time} — {Subject}";
    }
}

public interface IScheduleSortStrategy
{
    List<StrategyLesson> Sort(List<StrategyLesson> lessons);
}

public class SortBySubjectStrategy : IScheduleSortStrategy
{
    public List<StrategyLesson> Sort(List<StrategyLesson> lessons)
    {
        return lessons
            .OrderBy(lesson => lesson.Subject)
            .ToList();
    }
}

public class SortByTimeStrategy : IScheduleSortStrategy
{
    public List<StrategyLesson> Sort(List<StrategyLesson> lessons)
    {
        return lessons
            .OrderBy(lesson => TimeOnly.Parse(lesson.Time))
            .ToList();
    }
}

public class ScheduleSorter
{
    private IScheduleSortStrategy strategy;

    public ScheduleSorter(IScheduleSortStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void SetStrategy(IScheduleSortStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public List<StrategyLesson> Sort(List<StrategyLesson> lessons)
    {
        return strategy.Sort(lessons);
    }
}
