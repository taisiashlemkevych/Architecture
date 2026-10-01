namespace ScheduleSolid.Models;

public class Lesson
{
    public int Id { get; set; }

    public string Subject { get; set; }

    public string Date { get; set; }

    public string Time { get; set; }

    public Teacher Teacher { get; set; }

    public StudentGroup Group { get; set; }

    public Classroom Classroom { get; set; }

    public Lesson(
        int id,
        string subject,
        string date,
        string time,
        Teacher teacher,
        StudentGroup group,
        Classroom classroom)
    {
        Id = id;
        Subject = subject;
        Date = date;
        Time = time;
        Teacher = teacher;
        Group = group;
        Classroom = classroom;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(
            $"[{Id}] {Subject} | {Date} | {Time} | " +
            $"Викладач: {Teacher.Name} | " +
            $"Група: {Group.Name} | " +
            $"Аудиторія: {Classroom.Number}");
    }
}