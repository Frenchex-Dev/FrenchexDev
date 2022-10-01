namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IBaseCommandRequest
{
    bool Tty { get; }
    string? WorkingDirectory { get; }
    string? BinPath { get; }
    int TimeoutMs { get; }
}