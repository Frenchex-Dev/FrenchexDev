namespace Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;

public abstract class WithWorkingDirectoryExecutionContext
{
    public string? WorkingDirectory { get; set; }

    public static string CreateTemporaryDirectory()
    {
        return Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
    }
}