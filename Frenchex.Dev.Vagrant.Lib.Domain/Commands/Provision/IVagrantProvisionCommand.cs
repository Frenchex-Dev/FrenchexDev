#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision;

public interface IVagrantProvisionCommand : IVagrantCommand<VagrantProvisionRequest, VagrantProvisionResponse>
{
}

public interface IVagrantProvisionRequestBuilder : IVagrantRequestBuilder<VagrantProvisionRequest>
{
    IVagrantProvisionRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantProvisionRequestBuilder WithProvisionWith(
        string provisionWith
    );
}

public class VagrantProvisionRequestBuilder : AbstractVagrantRequestBuilder, IVagrantProvisionRequestBuilder
{
    private readonly List<string> _provisionWith = new();
    private          string       _nameOrId      = string.Empty;

    public VagrantProvisionRequest Build()
    {
        return new VagrantProvisionRequest(_nameOrId, _provisionWith.ToArray(), BaseBuilder.Color
                                         , BaseBuilder.MachineReadable, BaseBuilder.Version, BaseBuilder.Debug
                                         , BaseBuilder.Timestamp, BaseBuilder.DebugTimestamp, BaseBuilder.NoTty
                                         , BaseBuilder.Help);
    }

    public IVagrantProvisionRequestBuilder WithNameOrId(
        string nameOrId
    )
    {
        _nameOrId = nameOrId;
        return this;
    }

    public IVagrantProvisionRequestBuilder WithProvisionWith(
        string provisionWith
    )
    {
        _provisionWith.Add(provisionWith);
        return this;
    }
}
