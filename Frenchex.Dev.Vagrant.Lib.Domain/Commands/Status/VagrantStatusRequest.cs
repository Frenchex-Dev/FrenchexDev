#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

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
    IVagrantStatusRequestBuilder WithNameOrId(string nameOrId);
}

public class VagrantStatusRequestBuilder : AbstractVagrantRequestBuilder, IVagrantStatusRequestBuilder
{
    private string _nameOrId = string.Empty;

    public VagrantStatusRequest Build()
    {
        return new VagrantStatusRequest(_nameOrId, BaseBuilder.Color, BaseBuilder.MachineReadable, BaseBuilder.Version
                                      , BaseBuilder.Debug, BaseBuilder.Timestamp, BaseBuilder.DebugTimestamp
                                      , BaseBuilder.NoTty, BaseBuilder.Help);
    }

    public IVagrantStatusRequestBuilder WithNameOrId(string nameOrId)
    {
        _nameOrId = nameOrId;
        return this;
    }
}
