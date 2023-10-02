﻿#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;

public interface IVagrantUpRequestBuilder : IVagrantRequestBuilder<VagrantUpRequest>
{
    IVagrantUpRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantUpRequestBuilder WithProvision(
        bool provision
    );

    IVagrantUpRequestBuilder WithProvisionWith(
        string provision
    );

    IVagrantUpRequestBuilder WithDestroyOnError(
        bool destroyOnError
    );

    IVagrantUpRequestBuilder WithParallel(
        bool parallel
    );

    IVagrantUpRequestBuilder WithProvider(
        string provider
    );

    IVagrantUpRequestBuilder WithInstallProvider(
        bool installProvider
    );
}