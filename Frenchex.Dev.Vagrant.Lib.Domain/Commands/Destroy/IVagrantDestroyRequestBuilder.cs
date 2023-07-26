#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public interface IVagrantDestroyRequestBuilder : IVagrantRequestBuilder<VagrantDestroyRequest>
{
    IVagrantDestroyRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantDestroyRequestBuilder WithGraceful(
        bool graceful
    );

    IVagrantDestroyRequestBuilder WithForce(
        bool force
    );

    IVagrantDestroyRequestBuilder WithParallel(
        bool parallel
    );
}
