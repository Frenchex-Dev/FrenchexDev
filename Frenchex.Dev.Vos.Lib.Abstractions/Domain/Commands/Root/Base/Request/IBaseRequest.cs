namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseRequest
{
    bool Color { get; init; }
    bool MachineReadable { get; init; }
    bool Version { get; init; }
    bool Debug { get; init; }
    bool Timestamp { get; init; }
    bool DebugTimestamp { get; init; }
    bool Tty { get; init; }
    bool Help { get; }
    string? WorkingDirectory { get; init; }
    string? Timeout { get; init; }
    string? VagrantBinPath { get; init; }
    CancellationToken? CancellationToken { get; init; }
    T Parent<T>(T parent);
}