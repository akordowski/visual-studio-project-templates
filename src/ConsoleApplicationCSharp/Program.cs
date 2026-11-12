using ConsoleApplicationCSharp.Commands.Branch;
using ConsoleApplicationCSharp.Commands.Default;
using ConsoleApplicationCSharp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApplicationCSharp;

[ExcludeFromCodeCoverage]
public class Program
{
    private static Task<int> Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddLogging(args)
            .AddServices();

        var registrar = new TypeRegistrar(services);
        var resolver = registrar.Build();

        var app = new CommandApp(registrar);
        app.Configure(config =>
        {
            config.SetApplicationCulture(Global.Culture);
            config.SetApplicationName(Global.Name);
            config.SetApplicationVersion(Global.Version);

            config.AddCommand<DefaultCommand>("default");

            config.AddBranch<BranchSettings>("branch", config =>
            {
                config.SetDescription("branch description");

                config.AddCommand<BranchSubCommand>("branch-sub")
                    .WithDescription("branch sub description");
            });
        });

        return app.RunAsync(args);
    }
}
