#region Usings

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Provision;

public interface IVagrantProvisionRequest : IVagrantCommandRequest
{
    string   NameOrId      { get; }
    string[] ProvisionWith { get; }
}
