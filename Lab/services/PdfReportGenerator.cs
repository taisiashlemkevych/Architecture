using ScheduleSolid.Interfaces;

namespace ScheduleSolid.Services;

public class PdfReportGenerator : IReportGenerator
{
    public void GenerateReport()
    {
        Console.WriteLine(
            "[PDF Report] Формування PDF-звіту про розклад...");
    }
}
