using FastReport;
using FastReport.Export.PdfSimple;

namespace ims.Reporting.Reports;

public class ReportGenerator
{

    private int[]? array;
    private static string inFolder = @"C:\Users\Leo\source\repos\ims\ims.Reporting\Templates";

    private void CreateArray()
    {
        array = new int[100];
        for (int i = 0; i < 100; i++)
        {
            array[i] = i + 1;
        }
    }

    public void Generate()
    {
        CreateArray();

        // create report instance
        Report report = new();

        report.Load($@"{inFolder}\report.frx");

        // register the array
        report.RegisterData(array, "Array");

        // prepare the report
        report.Prepare();

        PDFSimpleExport pdfExport = new();

        report.Export(pdfExport, $@"{inFolder}\report.pdf");

        // free resources used by report
        report.Dispose();
    }
}
