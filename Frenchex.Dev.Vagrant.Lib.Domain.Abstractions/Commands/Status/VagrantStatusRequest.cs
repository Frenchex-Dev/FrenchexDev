#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public class VagrantStatusRequest : BaseVagrantCommandRequest, IVagrantStatusRequest
{
    public VagrantStatusRequest(
        string nameOrId
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
    }

    public string NameOrId { get; }
}

public interface IVagrantStatusRequestBuilder : IVagrantRequestBuilder<VagrantStatusRequest>
{
    IVagrantStatusRequestBuilder WithNameOrId(
        string nameOrId
    );
}

