using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;

/// <summary>
/// 
/// </summary>
public class VagrantInitRequest : BaseVagrantCommandRequest
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string BoxVersion { get; set; }
    public bool Force { get; set; }
    public bool Minimal { get; set; }
    public string Outfile { get; set; }
    public string Template { get; set; }
    public bool Color { get; set; }
    public bool MachineReadable { get; set; }
    public bool Version { get; set; }
    public bool Debug { get; set; }
    public bool Timestamp { get; set; }
    public bool DebugTimestamp { get; set; }
    public bool NoTty { get; set; }
}