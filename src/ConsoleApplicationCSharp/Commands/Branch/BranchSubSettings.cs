using Spectre.Console.Cli;
using System.ComponentModel;

namespace ConsoleApplicationCSharp.Commands.Branch;

public sealed class BranchSubSettings : BranchSettings
{
    [CommandOption("--option1", isRequired: true)]
    [Description("Option1")]
    public string Option1 { get; set; } = null!;

    [CommandOption("--option2")]
    [Description("Option2")]
    public int Option2 { get; set; }
}
