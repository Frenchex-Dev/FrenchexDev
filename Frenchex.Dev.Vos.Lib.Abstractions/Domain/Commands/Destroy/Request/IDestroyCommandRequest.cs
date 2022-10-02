using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequest : IRootCommandRequest
{
    string Name { get; }
    bool Force { get; }
    bool Parallel { get; }
    bool Graceful { get; }
    string? DestroyTimeout { get; }
}