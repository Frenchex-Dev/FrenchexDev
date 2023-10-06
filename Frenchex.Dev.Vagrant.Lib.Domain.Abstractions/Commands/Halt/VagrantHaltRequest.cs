#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt
{
    /// <summary>
    /// </summary>
    public class VagrantHaltRequest(
        string? nameOrId
      , bool    force
      , bool?   color
      , bool?   machineReadable
      , bool?   version
      , bool?   debug
      , bool?   timestamp
      , bool?   debugTimestamp
      , bool?   tty
      , bool?   help
    ) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help), IVagrantHaltRequest
    {
        public string? NameOrId { get; } = nameOrId;
        public bool    Force    { get; } = force;
    }
}
