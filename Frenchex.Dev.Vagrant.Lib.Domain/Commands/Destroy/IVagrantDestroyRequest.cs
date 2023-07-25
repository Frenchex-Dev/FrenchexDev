#region Usings

using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;

public interface IVagrantDestroyRequest : IVagrantCommandRequest
{
    string NameOrId { get; }
    bool   Force    { get; }
    bool   Parallel { get; }
    bool   Graceful { get; }
}
