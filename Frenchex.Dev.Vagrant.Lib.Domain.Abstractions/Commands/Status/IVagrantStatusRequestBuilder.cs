#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public interface IVagrantStatusRequestBuilder : IVagrantRequestBuilder<VagrantStatusRequest>
{
    IVagrantStatusRequestBuilder WithNameOrId(
        string nameOrId
    );
}
