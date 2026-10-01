namespace ScheduleSolid.Models;

public class StudentGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public StudentGroup(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Група: {Name}");
    }
}