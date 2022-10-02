using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequest : IRootCommandRequest
{
    string NameOrId { get; }
    bool Force { get; }
    bool Parallel { get; }
    bool Graceful { get; }
    int DestroyTimeoutInMs { get; }
}