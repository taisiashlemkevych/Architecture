using ScheduleSolid.Interfaces;

namespace ScheduleSolid.Services;

public class HtmlReportGenerator : IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine("[HTML Report] Формування HTML-звіту для веб-порталу...");
    }
}
