#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

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
        string? timeout,
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
        Timeout = timeout;
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
    public string? Timeout { get; }
}