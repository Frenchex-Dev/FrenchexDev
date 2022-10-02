namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

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
        string? vagrantBinPath
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
    }

    public bool Color { get; }
    public bool MachineReadable { get; }
    public bool Version { get; }
    public bool Debug { get; }
    public bool Timestamp { get; }
    public bool DebugTimestamp { get; }
    public bool Tty { get; }
    public bool Help { get; }
    public string? WorkingDirectory { get; }
    public string? Timeout { get; }
    public string? VagrantBinPath { get; }

    public T Parent<T>(T parent)
    {
        return parent;
    }

    public CancellationToken? CancellationToken { get; }
}