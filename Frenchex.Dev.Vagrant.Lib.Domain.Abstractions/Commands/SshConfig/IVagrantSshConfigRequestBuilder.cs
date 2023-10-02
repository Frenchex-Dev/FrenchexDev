﻿#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;

public interface IVagrantSshConfigRequestBuilder : IVagrantRequestBuilder<VagrantSshConfigRequest>
{
    IVagrantSshConfigRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantSshConfigRequestBuilder WithHost(
        string host
    );
}