// Без дотримання принципу Protected Variations (стійкість до змін)
public class ScheduleGenerator
{
    private LocalHolidayCalendar _calendar = new LocalHolidayCalendar();

    public void Generate()
    {
        if (!_calendar.IsHoliday(DateTime.Now))
        {
            // Генерація...
        }
    }
}

// З дотриманням принципу Protected Variations (стійкість до змін)
public interface IHolidayChecker { bool IsHoliday(DateTime date); }

public class ScheduleGenerator
{
    private readonly IHolidayChecker _holidayChecker;

    public ScheduleGenerator(IHolidayChecker holidayChecker)
    {
        _holidayChecker = holidayChecker;
    }

    public void Generate()
    {
        if (!_holidayChecker.IsHoliday(DateTime.Now))
        {
            // Генерація...
        }
    }
}
