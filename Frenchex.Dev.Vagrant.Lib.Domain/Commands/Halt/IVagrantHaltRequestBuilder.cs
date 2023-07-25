#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;

public interface IVagrantHaltRequestBuilder : IVagrantRequestBuilder<VagrantHaltRequest>
{
    IVagrantHaltRequestBuilder WithNameOrId(string nameOrId);
    IVagrantHaltRequestBuilder WithForce(bool      force);
}
