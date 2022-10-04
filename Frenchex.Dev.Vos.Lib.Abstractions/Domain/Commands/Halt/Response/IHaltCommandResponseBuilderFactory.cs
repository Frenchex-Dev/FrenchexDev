using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IHaltCommandResponseBuilder Factory();
}