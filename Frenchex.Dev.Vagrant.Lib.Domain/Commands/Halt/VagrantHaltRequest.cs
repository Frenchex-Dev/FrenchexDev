#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

/// <summary>
/// </summary>
public class VagrantHaltRequest : BaseVagrantCommandRequest, IVagrantHaltRequest
{
    public VagrantHaltRequest(
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
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, tty, help)
    {
        NameOrId = nameOrId;
        Force    = force;
    }

    public string? NameOrId { get; }
    public bool    Force    { get; }
}
