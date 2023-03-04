namespace ims.Reporting.ReportService;

public interface IReportService
{
    byte[] GenerateReport(ReportType reportType = ReportType.PDF);
}
