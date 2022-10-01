using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequest : IBaseCommandRequest
{
    public BaseCommandRequest(
        string workingDirectory,
        bool machineReadable = false,
        bool version = false,
        bool debug = false,
        string packerBinPath = "packer",
        int timeoutMs = -1,
        bool help = false,
        bool color = false
    )
    {
        WorkingDirectory = workingDirectory;
        Color = color;
        MachineReadable = machineReadable;
        Version = version;
        Help = help;
        TimeoutMs = timeoutMs;
        BinPath = packerBinPath ?? "packer";
        Debug = debug;
    }

    public bool MachineReadable { get; }
    public bool Version { get; }
    public bool Help { get; }
    public bool Debug { get; }
    public bool Color { get; }
    public bool Tty { get; }
    public string? WorkingDirectory { get; }
    public string? BinPath { get; }
    public int TimeoutMs { get; }
}