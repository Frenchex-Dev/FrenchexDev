#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequest : IBaseCommandRequest
{
    public BaseCommandRequest(
        string workingDirectory,
        bool timestamp,
        bool debugTimestamp,
        string? timeout,
        bool machineReadable = false,
        bool version = false,
        bool debug = false,
        string packerBinPath = "packer",
        bool help = false,
        bool color = false
    )
    {
        WorkingDirectory = workingDirectory;
        Timestamp = timestamp;
        DebugTimestamp = debugTimestamp;
        Color = color;
        MachineReadable = machineReadable;
        Version = version;
        Help = help;
        Timeout = timeout;
        BinPath = packerBinPath ?? "packer";
        Debug = debug;
    }

    public bool MachineReadable { get; }
    public bool Version { get; }
    public bool DebugTimestamp { get; }
    public bool Help { get; }
    public bool Debug { get; }
    public bool Timestamp { get; }
    public bool Color { get; }
    public bool Tty { get; }
    public string? WorkingDirectory { get; }
    public string? BinPath { get; }
    public string? Timeout { get; }
}