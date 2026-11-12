using System.Runtime.CompilerServices;

namespace XUnitCSharp;

public class VerifyModuleInitializer
{
    [ModuleInitializer]
    public static void Init()
    {
        // Source: https://github.com/VerifyTests/Verify/blob/main/docs/naming.md#derivepathinfo
        Verifier.DerivePathInfo((_, projectDirectory, _, _) =>
            new PathInfo(directory: Path.Combine(projectDirectory, "_Verify")));
    }
}
