using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public interface IVagrantStatusRequestBuilder : IVagrantRequestBuilder<VagrantStatusRequest>
{
    IVagrantStatusRequestBuilder WithNameOrId(
        string nameOrId
    );
}
