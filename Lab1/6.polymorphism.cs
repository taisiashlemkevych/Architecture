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
