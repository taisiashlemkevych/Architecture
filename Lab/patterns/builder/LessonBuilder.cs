using ScheduleSolid.Models;
namespace ScheduleSolid.Patterns.Builder;

public class LessonBuilder
{
private int id;
private string subject = "Не вказано";
private string date = "Не вказано";
private string time = "Не вказано";
private Teacher teacher = new(0, "Не вказано");
private StudentGroup group = new(0, "Не вказано");
private Classroom classroom = new(0, 0);

public LessonBuilder SetId(int id)
{
    this.id = id;
    return this;
}

public LessonBuilder SetSubject(string subject)
{
    this.subject = subject;
    return this;
}

public LessonBuilder SetDate(string date)
{
    this.date = date;
    return this;
}

public LessonBuilder SetTime(string time)
{
    this.time = time;
    return this;
}

public LessonBuilder SetTeacher(Teacher teacher)
{
    this.teacher = teacher;
    return this;
}

public LessonBuilder SetGroup(StudentGroup group)
{
    this.group = group;
    return this;
}

public LessonBuilder SetClassroom(Classroom classroom)
{
    this.classroom = classroom;
    return this;
}

public Lesson Build()
{
    return new Lesson(
        id,
        subject,
        date,
        time,
        teacher,
        group,
        classroom
    );
}
}
