using AspNetCore.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ims.Reporting.ReportService;

public abstract class BaseReportService
{
    private const string templateRootFolder = @"Templates";
    protected string reportName { get; private set; }
    protected LocalReport report { get; private set; }


    protected BaseReportService(string reportName)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Encoding.GetEncoding("utf-8");
        this.reportName = reportName;
        string rdlcFilePath = $"{templateRootFolder}/{reportName}.rdlc";
        report = new LocalReport(rdlcFilePath);
    }

    public static RenderType GetRenderType(ReportType reportType)
    => reportType switch
    {
        ReportType.EXCEL => RenderType.ExcelOpenXml,
        ReportType.WORD => RenderType.WordOpenXml,
        ReportType.IMAGE => RenderType.Image,
        ReportType.PDF => RenderType.Pdf,
        _ => throw new Exception("Report type not known!"),
    };

}
