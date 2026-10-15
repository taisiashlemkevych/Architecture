namespace ScheduleSolid.Patterns.Flyweight;

public class ClassroomFlyweight
{
    public int Number { get; }
    public int Capacity { get; }

    public ClassroomFlyweight(int number, int capacity)
    {
        Number = number;
        Capacity = capacity;
    }

    public void Display(string subject, string time)
    {
        Console.WriteLine(
            $"Аудиторія {Number}, місць: {Capacity}, " +
            $"предмет: {subject}, час: {time}");
    }
}

public class ClassroomFactory
{
    private readonly Dictionary<int, ClassroomFlyweight> classrooms = new();

    public ClassroomFlyweight GetClassroom(int number, int capacity)
    {
        if (classrooms.TryGetValue(number, out ClassroomFlyweight? classroom))
        {
            return classroom;
        }

        classroom = new ClassroomFlyweight(number, capacity);
        classrooms[number] = classroom;

        return classroom;
    }
}