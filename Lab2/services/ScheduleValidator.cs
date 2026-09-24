using ScheduleSolid.Models;

namespace ScheduleSolid.Services;

public class ScheduleValidator
{
    public bool HasConflict(Lesson newLesson, IEnumerable<Lesson> lessons)
    {
        foreach (Lesson lesson in lessons)
        {
            bool sameTime =
                lesson.Date == newLesson.Date &&
                lesson.Time == newLesson.Time;

            bool sameTeacher =
                lesson.Teacher.Id == newLesson.Teacher.Id;

            bool sameGroup =
                lesson.Group.Id == newLesson.Group.Id;

            bool sameClassroom =
                lesson.Classroom.Number == newLesson.Classroom.Number;

            if (sameTime &&
                (sameTeacher || sameGroup || sameClassroom))
            {
                return true;
            }
        }

        return false;
    }

    public bool Validate(Lesson lesson, IEnumerable<Lesson> lessons)
    {
        if (string.IsNullOrWhiteSpace(lesson.Subject))
        {
            Console.WriteLine("Помилка: предмет не вказаний.");
            return false;
        }

        if (HasConflict(lesson, lessons))
        {
            Console.WriteLine(
                "Помилка: виявлено конфлікт у розкладі.");

            return false;
        }

        return true;
    }
}
