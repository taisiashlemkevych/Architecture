//Без дотмання принципу Indirection
public class UIClient
{
    public void ShowSchedule(RemoteUniversityDb db) 
    {
        var schedule = db.DownloadSchedule(); 
        Console.WriteLine(schedule);
    }
}

//З дотриманням Indirection
public class ScheduleCacheProxy
{
    private readonly RemoteUniversityDb _db;
    private Schedule _cache;

    public Schedule GetSchedule()
    {
        if (_cache == null) _cache = _db.DownloadSchedule();
        return _cache;
    }
}