using Spectre.Console.Cli;

namespace ConsoleApplicationCSharp.Commands.Branch;

public sealed class BranchCommand : AsyncCommand<BranchSettings>
{
    public override Task<int> ExecuteAsync(
        CommandContext context,
        BranchSettings settings,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(ExitCodes.Ok);
    }
}
