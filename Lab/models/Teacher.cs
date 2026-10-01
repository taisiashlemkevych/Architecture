namespace ScheduleSolid.Models;

public class Teacher
{
    public int Id { get; set; }

    public string Name { get; set; }

    public Teacher(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Викладач: {Name}");
    }
}