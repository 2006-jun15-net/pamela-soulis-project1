using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace pamela_soulis_project1.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();


            //logging:
            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration)
            //    .CreateLogger();

            //try
            //{
            //    Log.Information("Starting web host");
            //    CreateHostBuilder(args).Build().Run();
            //    return 0;
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
            //    return 1;
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}


            //in appsettings.json
            //"Serilog": {
            //    "Using": [ "Serilog.Sinks.Debug" ],
            //    "MinimumLevel": {
            //        "Default": "Debug",
            //        "Override": {
            //            "Microsoft": "Error"
            //        }
            //    },
            //    "WriteTo": [
            //        { "Name": "Debug" },
            //        {
            //            "Name": "File",
            //            "Args": {
            //                "path": "Logs\\log.txt",
            //                "rollingInterval": "Day",
            //                "retainedFileCountLimit": 31
            //            }
            //        }
            //    ]
            //}



        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        //.UseSerilog()
                        .UseStartup<Startup>();
                });
    }
}
