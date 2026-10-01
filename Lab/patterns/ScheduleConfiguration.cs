namespace ScheduleSolid.Patterns;

public sealed class ScheduleConfiguration
{
    private static ScheduleConfiguration? instance;

    public static ScheduleConfiguration Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ScheduleConfiguration();
            }

            return instance;
        }
    }

    public string UniversityName { get; set; }
    public string AcademicYear { get; set; }
    public int LessonDurationMinutes { get; set; }

    private ScheduleConfiguration()
    {
        UniversityName = "Чернівецький університет";
        AcademicYear = "2026-2027";
        LessonDurationMinutes = 90;
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"Університет: {UniversityName}");
        Console.WriteLine($"Навчальний рік: {AcademicYear}");
        Console.WriteLine(
            $"Тривалість заняття: {LessonDurationMinutes} хв.");
    }
}