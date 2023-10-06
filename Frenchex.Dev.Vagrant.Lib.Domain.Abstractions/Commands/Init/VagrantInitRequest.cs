#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init
{
    /// <summary>
    ///     Represents a Vagrant Init command request
    /// </summary>
    public class VagrantInitRequest(
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
    ) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help), IVagrantInitRequest
    {
        public string? Name       { get; set; } = name;
        public string? Url        { get; set; } = url ?? string.Empty;
        public string? BoxVersion { get; set; } = boxVersion;
        public bool    Force      { get; set; } = force;
        public bool    Minimal    { get; set; } = minimal;
        public string? Output     { get; set; } = output;
        public string? Template   { get; set; } = template;
    }
}
