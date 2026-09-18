// Без дотримання принципу Polymorphism
public class Lesson
{
    public string Type { get; set; } // "Lecture" або "Lab"

    public string GetRoomRequirement()
    {
        if (Type == "Lecture") return "Великий зал";
        if (Type == "Lab") return "Комп'ютерний клас";
        return "Звичайна аудиторія";
    }
}


// З дотриманням принципу Polymorphism
public abstract class LessonType
{
    public abstract string GetRoomRequirement();
}

public class Lecture : LessonType
{
    public override string GetRoomRequirement() => "Великий зал";
}

public class LaboratoryWork : LessonType
{
    public override string GetRoomRequirement() => "Комп'ютерний клас";
}

