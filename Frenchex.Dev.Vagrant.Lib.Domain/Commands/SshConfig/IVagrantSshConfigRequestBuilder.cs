#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;

public interface IVagrantSshConfigRequestBuilder : IVagrantRequestBuilder<VagrantSshConfigRequest>
{
    IVagrantSshConfigRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantSshConfigRequestBuilder WithHost(
        string host
    );
}
