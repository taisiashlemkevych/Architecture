namespace ScheduleSolid.Patterns.Observer;

public interface IScheduleObserver
{
    void Update(string message);
}

public class ObserverStudent : IScheduleObserver
{
    public string Name { get; }

    public ObserverStudent(string name)
    {
        Name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{Name} отримав повідомлення: {message}");
    }
}

public class ObserverSchedule
{
    private readonly List<IScheduleObserver> observers = new();

    public void Subscribe(IScheduleObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IScheduleObserver observer)
    {
        observers.Remove(observer);
    }

    public void ChangeSchedule(string message)
    {
        Console.WriteLine($"Розклад змінено: {message}");

        foreach (IScheduleObserver observer in observers)
        {
            observer.Update(message);
        }
    }
}
