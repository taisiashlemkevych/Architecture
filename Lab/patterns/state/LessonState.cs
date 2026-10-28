namespace ScheduleSolid.Patterns.State;

public interface ILessonState
{
    void Start(LessonContext context);
    void Finish(LessonContext context);
    void Display();
}

public class PlannedState : ILessonState
{
    public void Start(LessonContext context)
    {
        Console.WriteLine("Заняття розпочалося.");
        context.SetState(new InProgressState());
    }

    public void Finish(LessonContext context)
    {
        Console.WriteLine("Не можна завершити заняття, яке ще не почалося.");
    }

    public void Display()
    {
        Console.WriteLine("Стан заняття: заплановане.");
    }
}

public class InProgressState : ILessonState
{
    public void Start(LessonContext context)
    {
        Console.WriteLine("Заняття вже триває.");
    }

    public void Finish(LessonContext context)
    {
        Console.WriteLine("Заняття завершено.");
        context.SetState(new FinishedState());
    }

    public void Display()
    {
        Console.WriteLine("Стан заняття: триває.");
    }
}

public class FinishedState : ILessonState
{
    public void Start(LessonContext context)
    {
        Console.WriteLine("Завершене заняття не можна розпочати повторно.");
    }

    public void Finish(LessonContext context)
    {
        Console.WriteLine("Заняття вже завершене.");
    }

    public void Display()
    {
        Console.WriteLine("Стан заняття: завершене.");
    }
}

public class LessonContext
{
    private ILessonState state;

    public LessonContext()
    {
        state = new PlannedState();
    }

    public void SetState(ILessonState newState)
    {
        state = newState;
    }

    public void Start()
    {
        state.Start(this);
    }

    public void Finish()
    {
        state.Finish(this);
    }

    public void Display()
    {
        state.Display();
    }
}
