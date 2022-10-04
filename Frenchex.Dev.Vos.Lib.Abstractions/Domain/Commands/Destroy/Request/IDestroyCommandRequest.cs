using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequest : IRootCommandRequest
{
    string Name { get; }
    bool Force { get; }
    bool Parallel { get; }
    bool Graceful { get; }
    string? DestroyTimeout { get; }
}