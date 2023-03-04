using ims.Reporting.ReportService;
using ims.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
/*
UserReportService userReportService = new();

var bytes = userReportService.GenerateReport();
File.WriteAllBytes("C:\\Users\\Leo\\source\\repos\\ims\\ims.Reporting\\Templates\\report.pdf", bytes);
*/
IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });

CreateHostBuilder(args).Build().Run();

