#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy
{
    public class VagrantDestroyRequest(
        string nameOrId
      , bool   force
      , bool   parallel
      , bool   graceful
      , bool?  color
      , bool?  machineReadable
      , bool?  version
      , bool?  debug
      , bool?  timestamp
      , bool?  debugTimestamp
      , bool?  noTty
      , bool?  help
    ) : BaseVagrantCommandRequest(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help), IVagrantDestroyRequest
    {
        public string NameOrId { get; } = nameOrId;
        public bool   Force    { get; } = force;
        public bool   Parallel { get; } = parallel;
        public bool   Graceful { get; } = graceful;
    }
}
