#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

public class VagrantDestroyRequest : BaseVagrantCommandRequest, IVagrantDestroyRequest
{
    public VagrantDestroyRequest(
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
    ) : base(color, machineReadable, version, debug, timestamp, debugTimestamp, noTty, help)
    {
        NameOrId = nameOrId;
        Force    = force;
        Parallel = parallel;
        Graceful = graceful;
    }

    public string NameOrId { get; }
    public bool   Force    { get; }
    public bool   Parallel { get; }
    public bool   Graceful { get; }
}
