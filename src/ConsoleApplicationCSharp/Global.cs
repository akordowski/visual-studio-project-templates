using System.Globalization;
using System.Reflection;

namespace ConsoleApplicationCSharp;

internal static class Global
{
    public static CultureInfo Culture { get; } = new("en-US");
    public static string Name { get; } = Assembly.GetExecutingAssembly().GetName().Name!;
    public static string Version { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)!;
}
