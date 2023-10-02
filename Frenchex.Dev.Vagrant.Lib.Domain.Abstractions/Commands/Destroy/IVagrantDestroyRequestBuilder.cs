#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

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
