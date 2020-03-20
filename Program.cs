using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace ViewCompDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using NLOG
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()

                        // configure logging and use NLOG
                        .ConfigureLogging(logging => {
                            logging.ClearProviders();
                            logging.SetMinimumLevel(LogLevel.Trace);
                        })
                        .UseNLog();
                });


        // - Configure logging programmatically, via Configuration API - to use NLOG
        // public static void Main(string[] args)
        // {
        //     var config = new LoggingConfiguration();    // instantiate the Logging Configuration
            
        //     // targets
        //     var fileTarget = new FileTarget("fileTarget")   // NLOG's targets
        //     {
        //         FileName = @"c:\logs\mylog-${shortdate}.log",
        //         Layout = "${longdate}|${event-properties:item=EventId_Id}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}"
        //     };
        //     config.AddTarget(fileTarget);

        //     // rules                                        // NLOG's rules
        //     config.AddRuleForOneLevel(NLog.LogLevel.Warn, fileTarget); 
        //     config.AddRuleForOneLevel(NLog.LogLevel.Error, fileTarget);
        //     config.AddRuleForOneLevel(NLog.LogLevel.Fatal, fileTarget);  
        //     LogManager.Configuration = config;
        //     CreateWebHostBuilder(args).Build().Run();
        // }
        // -
    }
}
