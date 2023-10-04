#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

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
