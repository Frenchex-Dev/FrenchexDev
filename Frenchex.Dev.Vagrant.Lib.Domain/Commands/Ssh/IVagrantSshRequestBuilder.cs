#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;

public interface IVagrantSshRequestBuilder : IVagrantRequestBuilder<VagrantSshRequest>
{
    IVagrantSshRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantSshRequestBuilder WithCommand(
        string command
    );

    IVagrantSshRequestBuilder WithExtraSshArgs(
        string extraSshArgs
    );
}
