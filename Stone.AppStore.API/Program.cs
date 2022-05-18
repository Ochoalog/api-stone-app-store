using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Stone.AppStore.API
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;

        public static readonly string AppName = Namespace[(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1)..];

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static ILogger CreateSerilogLogger(IConfiguration configuration) => new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(AppDomain.CurrentDomain.BaseDirectory +
                    $"/logs/{nameof(Stone.AppStore)}_.log",
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    fileSizeLimitBytes: long.Parse(configuration["LogMaxSize"]),
                    retainedFileCountLimit: int.Parse(configuration["RetainedFileCountLimit"]),
                    outputTemplate: "{Timestamp:o} [{Level:u3}] # " +
                                    "{HttpRequestId} # {MachineName}{FullName} " +
                                    "{Message}{NewLine}{Exception}"
                    )
                .CreateLogger();
    }
}
