using ConsoleApplicationCSharp.Commands;
using ConsoleApplicationCSharp.Commands.Branch;
using ConsoleApplicationCSharp.Commands.Default;
using ConsoleApplicationCSharp.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace ConsoleApplicationCSharp;

[ExcludeFromCodeCoverage]
public class Program
{
    private static Task<int> Main(string[] args)
    {
        var services = new ServiceCollection()
            .AddLogging("project.log", args)
            .AddServices();

        var registrar = new TypeRegistrar(services);
        var resolver = registrar.Build();

        var cancellationTokenSource = new CancellationTokenSource();

        Console.CancelKeyPress += (_, e) =>
        {
            AnsiConsole.MarkupLine("[yellow]Operation cancellation requested...[/]");

            e.Cancel = true;
            cancellationTokenSource.Cancel();
        };

        var app = new CommandApp(registrar);
        app.Configure(config =>
        {
            config.SetApplicationCulture(Global.Culture);
            config.SetApplicationName(Global.Name);
            config.SetApplicationVersion(Global.Version);

            config.AddCommand<DefaultCommand>("default");

            config.AddBranch<BranchSettings>("branch", branch =>
            {
                branch.SetDescription("branch description");

                branch.AddCommand<BranchSubCommand>("branch-sub")
                    .WithDescription("branch sub description");
            });

            config.SetExceptionHandler((ex, _) =>
            {
                if (ex is CommandRuntimeException)
                {
                    AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
                }
                else if (ex is OperationCanceledException)
                {
                    AnsiConsole.WriteLine("Operation was canceled.");
                }
                else
                {
                    AnsiConsole.WriteException(ex);
                }

                return ex switch
                {
                    CommandRuntimeException => ExitCodes.DefaultError,
                    OperationCanceledException => ExitCodes.Canceled,
                    _ => ExitCodes.Error
                };
            });
        });

        return app.RunAsync(args);
    }
}
