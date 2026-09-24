using ScheduleSolid.Interfaces;
using ScheduleSolid.Models;

namespace ScheduleSolid.Services;

public class ScheduleManager : IScheduleReader, IScheduleWriter
{
    private readonly Schedule schedule;
    private readonly ScheduleValidator validator;
    private readonly INotificationService notificationService;

    public ScheduleManager(
        Schedule schedule,
        ScheduleValidator validator,
        INotificationService notificationService)
    {
        this.schedule = schedule;
        this.validator = validator;
        this.notificationService = notificationService;
    }

    public void AddLesson(Lesson lesson)
    {
        if (validator.Validate(lesson, schedule.Lessons))
        {
            schedule.AddLesson(lesson);

            notificationService.Send(
                $"Додано нове заняття: {lesson.Subject}");
        }
    }

    public void RemoveLesson(int lessonId)
    {
        schedule.RemoveLesson(lessonId);

        notificationService.Send(
            $"Операція видалення заняття з ID {lessonId} виконана.");
    }

    public void ReadSchedule()
    {
        schedule.DisplayLessons();
    }
}
