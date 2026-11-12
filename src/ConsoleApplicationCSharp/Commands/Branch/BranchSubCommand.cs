using Spectre.Console.Cli;

namespace ConsoleApplicationCSharp.Commands.Branch;

public sealed class BranchSubCommand : AsyncCommand<BranchSubSettings>
{
    public override Task<int> ExecuteAsync(
        CommandContext context,
        BranchSubSettings settings,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(ExitCodes.Ok);
    }
}
