using Common.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace OcelotApiGw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
              .ConfigureLogging(loggingBuilder =>
              {
                  loggingBuilder.Configure(options =>
                  {
                      options.ActivityTrackingOptions = ActivityTrackingOptions.TraceId | ActivityTrackingOptions.SpanId;
                  });
              })
                .UseSerilog(SeriLogger.Configure);

                //.ConfigureLogging((hostingContext, loggingBuilder) =>
                //{
                //    loggingBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //    loggingBuilder.AddConsole().AddDebug();
                //});
    }
}
