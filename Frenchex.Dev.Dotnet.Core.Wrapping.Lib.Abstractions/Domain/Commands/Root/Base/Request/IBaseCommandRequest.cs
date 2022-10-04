namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequest
{
    bool Tty { get; }
    string? WorkingDirectory { get; }
    string? BinPath { get; }
    string? Timeout { get; }
}