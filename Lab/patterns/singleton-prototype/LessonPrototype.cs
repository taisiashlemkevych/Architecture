using ScheduleSolid.Models;

namespace ScheduleSolid.Patterns.singletonPrototype;

public class LessonPrototype
{
    private readonly Lesson lesson;

    public LessonPrototype(Lesson lesson)
    {
        this.lesson = lesson;
    }

    public Lesson Clone()
    {
        return new Lesson(
            lesson.Id,
            lesson.Subject,
            lesson.Date,
            lesson.Time,
            new Teacher(
                lesson.Teacher.Id,
                lesson.Teacher.Name),
            new StudentGroup(
                lesson.Group.Id,
                lesson.Group.Name),
            new Classroom(
                lesson.Classroom.Number,
                lesson.Classroom.Capacity));
    }
}