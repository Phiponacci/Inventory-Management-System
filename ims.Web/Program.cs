using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ims.Reporting.Reports;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ims.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReportGenerator ge = new ReportGenerator();

            ge.Generate();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
