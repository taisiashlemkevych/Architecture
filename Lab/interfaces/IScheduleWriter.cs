using ScheduleSolid.Models;

namespace ScheduleSolid.Interfaces;

public interface IScheduleWriter
{
    void AddLesson(Lesson lesson);

    void RemoveLesson(int lessonId);
}
