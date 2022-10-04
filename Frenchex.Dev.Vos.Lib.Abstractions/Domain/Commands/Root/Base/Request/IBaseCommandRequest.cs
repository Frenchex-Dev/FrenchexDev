namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequest
{
    bool Color { get; }
    bool MachineReadable { get; }
    bool Version { get; }
    bool Debug { get; }
    bool Timestamp { get; }
    bool DebugTimestamp { get; }
    bool Tty { get; }
    bool Help { get; }
    string? WorkingDirectory { get; }
    string? Timeout { get; }
    string? VagrantBinPath { get; }
    CancellationToken? CancellationToken { get; }
    T Parent<T>(T parent);
}