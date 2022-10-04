using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequest : IRootCommandRequest
{
    string[] Names { get; }
    bool Force { get; }
    string? HaltTimeout { get; }
}