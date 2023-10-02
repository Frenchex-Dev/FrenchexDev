#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;

/// <summary>
///     Represents a Vagrant Init command request
/// </summary>
public class VagrantInitRequest : BaseVagrantCommandRequest, IVagrantInitRequest
{
    public VagrantInitRequest(
        string? name
      , string? url
      , string? boxVersion
      , bool    force
      , bool    minimal
      , string? output
      , string? template
      , bool?   color
      , bool?   machineReadable
      , bool?   version
      , bool?   debug
      , bool?   timestamp
      , bool?   debugTimestamp
      , bool?   tty
      , bool?   help
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help)
    {
        Name       = name;
        Url        = url ?? string.Empty;
        BoxVersion = boxVersion;
        Force      = force;
        Minimal    = minimal;
        Output     = output;
        Template   = template;
    }

    public string? Name       { get; set; }
    public string? Url        { get; set; }
    public string? BoxVersion { get; set; }
    public bool    Force      { get; set; }
    public bool    Minimal    { get; set; }
    public string? Output     { get; set; }
    public string? Template   { get; set; }
}
