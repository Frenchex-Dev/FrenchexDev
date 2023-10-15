#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Halt;

public interface IVagrantHaltRequestBuilder : IVagrantRequestBuilder<VagrantHaltRequest>
{
    IVagrantHaltRequestBuilder WithNameOrId(
        string nameOrId
    );

    IVagrantHaltRequestBuilder WithForce(
        bool force
    );
}
