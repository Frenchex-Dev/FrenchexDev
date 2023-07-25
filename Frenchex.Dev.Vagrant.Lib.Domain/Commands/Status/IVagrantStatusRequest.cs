#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;

public interface IVagrantStatusRequest : IVagrantCommandRequest
{
    string NameOrId { get; }
}
