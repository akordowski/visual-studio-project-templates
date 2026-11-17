using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System.Diagnostics.CodeAnalysis;
using Test1.Service;

namespace ConsoleApplicationCSharp.DependencyInjection;

[ExcludeFromCodeCoverage]
internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddLogging(string[] args)
        {
            const string outputTemplate = "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{LogEventLevel}] {Message}{NewLine}{Exception}";

            var excludeArgs = new[] { "-h", "--help", "-v", "--version" };
            var excludeFileLogger = args.Any(arg => excludeArgs.Contains(arg));
            var levelSwitch = new LoggingLevelSwitch();

            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Enrich.FromLogContext()
                .Enrich.With<LogEventLevelEnricher>()
                .WriteTo.Console(
                    outputTemplate: outputTemplate,
                    formatProvider: Global.Culture);

            if (!excludeFileLogger)
            {
                loggerConfig.WriteTo.File(
                    path: "project.log",
                    outputTemplate: outputTemplate,
                    formatProvider: Global.Culture);
            }

            Log.Logger = loggerConfig.CreateLogger();

            return services
                .AddSingleton(levelSwitch)
                .AddSingleton(Log.Logger);
        }

        public IServiceCollection AddServices()
        {
            return services.AddSingleton<IBranchSubService, BranchSubService>();
        }
    }
}
