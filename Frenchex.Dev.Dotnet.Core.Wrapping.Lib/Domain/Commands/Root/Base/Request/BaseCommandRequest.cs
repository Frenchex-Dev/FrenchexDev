using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequest : IBaseCommandRequest
{
    public BaseCommandRequest(
        string? workingDirectory,
        bool? tty,
        string? timeout,
        string? binPath
    )
    {
        WorkingDirectory = workingDirectory;
        BinPath = binPath;
        Timeout = timeout;
        Tty = tty ?? false;
    }

    public bool Tty { get; }
    public string? WorkingDirectory { get; }
    public string? BinPath { get; }
    public string? Timeout { get; }
}