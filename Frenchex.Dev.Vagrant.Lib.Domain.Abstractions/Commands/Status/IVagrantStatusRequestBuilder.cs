#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Base;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;

public interface IVagrantStatusRequestBuilder : IVagrantRequestBuilder<VagrantStatusRequest>
{
    IVagrantStatusRequestBuilder WithNameOrId(
        string nameOrId
    );
}