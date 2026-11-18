using Spectre.Console.Cli;
using System.ComponentModel;

namespace ConsoleApplicationCSharp.Commands.Branch;

public sealed class BranchSubSettings : BranchSettings
{
    [CommandOption("--str-option", isRequired: true)]
    [Description("StrOption")]
    public string StrOption { get; init; } = null!;

    [CommandOption("--numeric-option")]
    [Description("NumericOption")]
    public int NumericOption { get; init; }
}
