
using ims.ReportModel.Model;

namespace ims.Reporting.ReportService;

public class UserReportService : BaseReportService, IReportService
{
    public UserReportService() : base("UserReport")
    {
    }

    public byte[] GenerateReport(ReportType reportType = ReportType.PDF)
    {
        List<UserReportModel> userList = new();

        var user1 = new UserReportModel { Id = 1, UserName = "J.Doe", FirstName = "John", LastName = "Doe" };
        var user2 = new UserReportModel { Id = 2, UserName = "F.Moses", FirstName = "Frank", LastName = "Moses" };
        userList.Add(user1);
        userList.Add(user2);

        report.AddDataSource("UserDataSet", userList);

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        var result = report.Execute(GetRenderType(reportType), 1, parameters);
        return result.MainStream;
    }
}
