using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Base.Request;

public class BaseRequest : IBaseRequest
{
    public BaseRequest(
        bool color,
        bool machineReadable,
        bool version,
        bool debug,
        bool timestamp,
        bool debugTimestamp,
        bool tty,
        bool help,
        string? workingDirectory,
        string? timeoutString,
        string? vagrantBinPath,
        CancellationToken? cancellationToken
    )
    {
        Color = color;
        MachineReadable = machineReadable;
        Version = version;
        Debug = debug;
        Timestamp = timestamp;
        DebugTimestamp = debugTimestamp;
        Tty = tty;
        Help = help;
        WorkingDirectory = workingDirectory;
        Timeout = timeoutString;
        VagrantBinPath = vagrantBinPath;
        CancellationToken = cancellationToken;
    }

    public bool Color { get; init; }
    public bool MachineReadable { get; init; }
    public bool Version { get; init; }
    public bool Debug { get; init; }
    public bool Timestamp { get; init; }
    public bool DebugTimestamp { get; init; }
    public bool Tty { get; init; }
    public bool Help { get; init; }
    public string? WorkingDirectory { get; init; }
    public string? Timeout { get; init; }
    public string? VagrantBinPath { get; init; }

    public T Parent<T>(T parent)
    {
        return parent;
    }

    public CancellationToken? CancellationToken { get; init; }
}