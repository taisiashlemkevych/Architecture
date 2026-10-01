namespace ScheduleSolid.Models;

public class Classroom
{
    public int Number { get; set; }

    public int Capacity { get; set; }

    public Classroom(int number, int capacity)
    {
        Number = number;
        Capacity = capacity;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(
            $"Аудиторія: {Number}, місткість: {Capacity}");
    }
}