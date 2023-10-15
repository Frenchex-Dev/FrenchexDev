﻿#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

public interface IVagrantProvisionRequestBuilder : IVagrantRequestBuilder<VagrantProvisionRequest>
{
    IVagrantProvisionRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantProvisionRequestBuilder WithProvisionWith(
        string provisionWith
    );
}