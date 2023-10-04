#region Licensing

// Licensing please read LICENSE.md

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;

public interface IVagrantDestroyRequest : IVagrantCommandRequest
{
    string NameOrId { get; }
    bool   Force    { get; }
    bool   Parallel { get; }
    bool   Graceful { get; }
}
