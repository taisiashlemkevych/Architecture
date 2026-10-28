using ScheduleSolid.Patterns.Adapter;
using ScheduleSolid.Patterns.Bridge;
using ScheduleSolid.Patterns.Composite;
using ScheduleSolid.Patterns.Flyweight;
using ScheduleSolid.Patterns.Decorator;
using ScheduleSolid.Patterns.Proxy;
using ScheduleSolid.Patterns.ChainOfResponsibility;
using ScheduleSolid.Patterns.Command;
using ScheduleSolid.Patterns.Iterator;
using ScheduleSolid.Patterns.Mediator;
using ScheduleSolid.Patterns.Memento;
using ScheduleSolid.Patterns.Observer;

namespace ScheduleSolid;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("========== ADAPTER ==========");

        ExternalScheduleService externalService = new();
        IScheduleReader reader = new ScheduleAdapter(externalService);
        string schedule = reader.ReadSchedule();

        Console.WriteLine(schedule);

        Console.WriteLine("\n========== BRIDGE ==========");

        ScheduleReport consoleReport = new(new ConsoleScheduleOutput());
        consoleReport.Generate(schedule);

        ScheduleReport fileReport = new(new TextFileScheduleOutput());
        fileReport.Generate(schedule);

        Console.WriteLine("\n========== COMPOSITE ==========");

        ScheduleGroup scheduleGroup = new("Розклад групи КН-21");
        scheduleGroup.Add(new ScheduleLesson("Програмування", "10:00"));
        scheduleGroup.Add(new ScheduleLesson("Бази даних", "12:00"));

        ScheduleGroup afternoonGroup = new("Друга частина розкладу");
        afternoonGroup.Add(new ScheduleLesson("Математика", "14:00"));

        scheduleGroup.Add(afternoonGroup);
        scheduleGroup.Display();

        Console.WriteLine("\n========== FLYWEIGHT ==========");

        ClassroomFactory classroomFactory = new();

        ClassroomFlyweight room1 = classroomFactory.GetClassroom(101, 30);
        ClassroomFlyweight room2 = classroomFactory.GetClassroom(101, 30);

        room1.Display("Програмування", "10:00");
        room2.Display("Бази даних", "12:00");

        Console.WriteLine(
            $"Аудиторія повторно використана: {ReferenceEquals(room1, room2)}");

        Console.WriteLine("\n========== DECORATOR ==========");

        IScheduleInfo scheduleInfo = new BasicSchedule();
        scheduleInfo = new TeacherScheduleDecorator(scheduleInfo);
        scheduleInfo = new ClassroomScheduleDecorator(scheduleInfo);

        Console.WriteLine(scheduleInfo.GetInfo());

        Console.WriteLine("\n========== PROXY ==========");

        IScheduleService realService = new RealScheduleService();

        IScheduleService allowedProxy = new ScheduleProxy(realService, true);
        Console.WriteLine(allowedProxy.GetSchedule());

        IScheduleService deniedProxy = new ScheduleProxy(realService, false);
        Console.WriteLine(deniedProxy.GetSchedule());

        Console.WriteLine("\n========== CHAIN OF RESPONSIBILITY ==========");

        ScheduleHandler subjectCheck = new SubjectHandler();
        subjectCheck.SetNext(new ApprovalHandler());

        subjectCheck.Handle("Програмування");
        subjectCheck.Handle("Заборонено");

        Console.WriteLine("\n========== COMMAND ==========");

        ScheduleManager manager = new();

        IScheduleCommand addCommand =
            new AddLessonCommand(manager, "Програмування");

        IScheduleCommand removeCommand =
            new RemoveLessonCommand(manager, "Програмування");

        addCommand.Execute();
        manager.ShowLessons();

        removeCommand.Execute();
        manager.ShowLessons();

        Console.WriteLine("\n========== ITERATOR ==========");

        IteratorSchedule scheduleObj = new();

        scheduleObj.AddLesson("Програмування");
        scheduleObj.AddLesson("Бази даних");
        scheduleObj.AddLesson("Математика");

        ScheduleIterator iterator = scheduleObj.CreateIterator();

        while (iterator.HasNext())
        {
            string lesson = iterator.Next();
            Console.WriteLine(lesson);
        }

        Console.WriteLine("\n========== MEDIATOR ==========");

        ScheduleMediator mediator = new();

        MediatorStudent student1 = new("Олена");
        MediatorStudent student2 = new("Андрій");

        mediator.RegisterStudent(student1);
        mediator.RegisterStudent(student2);

        Teacher teacher = new(mediator);

        teacher.ChangeSchedule("Заняття перенесено на 12:00.");

        Console.WriteLine("\n========== MEMENTO ==========");

        MementoSchedule mementoSchedule = new("Програмування");

        mementoSchedule.Display();

        ScheduleMemento savedState = mementoSchedule.Save();

        mementoSchedule.ChangeLesson("Бази даних");
        mementoSchedule.Display();

        mementoSchedule.Restore(savedState);
        mementoSchedule.Display();

        Console.WriteLine("\n========== OBSERVER ==========");

        ObserverSchedule observerSchedule = new();

        ObserverStudent observerStudent1 = new("Олена");
        ObserverStudent observerStudent2 = new("Андрій");

        observerSchedule.Subscribe(observerStudent1);
        observerSchedule.Subscribe(observerStudent2);

        observerSchedule.ChangeSchedule(
            "Заняття з програмування перенесено на 12:00.");

        observerSchedule.Unsubscribe(observerStudent1);

        observerSchedule.ChangeSchedule(
            "Наступне заняття відбудеться в аудиторії 205.");
    }
}
