using Spectre.Console;
using Spectre.Console.Cli;

namespace ConsoleApplicationCSharp.Commands.Branch;

public sealed class BranchSubCommand : AsyncCommand<BranchSubSettings>
{
    private readonly IBranchSubService _service;

    public BranchSubCommand(IBranchSubService service)
    {
        ArgumentNullException.ThrowIfNull(service);
        _service = service;
    }

    public override async Task<int> ExecuteAsync(
        CommandContext context,
        BranchSubSettings settings,
        CancellationToken cancellationToken)
    {
        var result = await _service.ExecuteAsync(cancellationToken);

        return result.IsSuccess
            ? ExitCodes.Ok
            : ExitCodes.Error;
    }

    public override ValidationResult Validate(CommandContext context, BranchSubSettings settings)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(settings.StrOption))
        {
            return ValidationResult.Error("StrOption must not be empty or whitespace");
        }

        if (settings.NumericOption <= 0)
        {
            return ValidationResult.Error("NumericOption must not be less or equal 0");
        }

        return base.Validate(context, settings);
    }
}
