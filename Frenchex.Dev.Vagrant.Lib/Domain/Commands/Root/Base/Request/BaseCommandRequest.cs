using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequest : IBaseCommandRequest
{
    public BaseCommandRequest(
        string? workingDirectory,
        bool? color,
        bool? machineReadable,
        bool? version,
        bool? debug,
        bool? timestamp,
        bool? debugTimestamp,
        bool? tty,
        bool? help,
        int? timeoutMs,
        string? vagrantBinPath
    )
    {
        WorkingDirectory = workingDirectory;
        Color = color ?? false;
        MachineReadable = machineReadable ?? false;
        Version = version ?? false;
        Debug = debug ?? false;
        Timestamp = timestamp ?? false;
        DebugTimestamp = debugTimestamp ?? false;
        Tty = tty ?? false;
        Help = help ?? false;
        TimeoutMs = timeoutMs ?? (int) -1;
        BinPath = vagrantBinPath ?? "vagrant";
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
    public string? BinPath { get; }
    public int TimeoutMs { get; }
}