using Spectre.Console.Cli;

namespace ConsoleApplicationCSharp.Commands.Default;

public sealed class DefaultCommand : AsyncCommand<DefaultSettings>
{
    public override Task<int> ExecuteAsync(
        CommandContext context,
        DefaultSettings settings,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(ExitCodes.Ok);
    }
}
