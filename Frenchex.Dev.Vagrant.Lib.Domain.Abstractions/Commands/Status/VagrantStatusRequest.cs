#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status
{
    public class VagrantStatusRequest(
        string nameOrId
      , bool?  color
      , bool?  machineReadable
      , bool?  version
      , bool?  debug
      , bool?  timestamp
      , bool?  debugTimestamp
      , bool?  noTty
      , bool?  help
    ) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help), IVagrantStatusRequest
    {
        public string NameOrId { get; } = nameOrId;
    }
}
