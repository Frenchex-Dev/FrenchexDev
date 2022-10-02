namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public class CommandRequestHolder : IBaseCommandRequest
{
    public CommandRequestHolder(
        string? workingDirectory,
        bool? tty,
        int? timeoutMs,
        string? binPath
    )
    {
        WorkingDirectory = workingDirectory;
        BinPath = binPath;
        TimeoutMs = timeoutMs ?? -1;
        Tty = tty ?? false;
    }

    public bool Tty { get; }
    public string? WorkingDirectory { get; }
    public string? BinPath { get; }
    public int TimeoutMs { get; }
}