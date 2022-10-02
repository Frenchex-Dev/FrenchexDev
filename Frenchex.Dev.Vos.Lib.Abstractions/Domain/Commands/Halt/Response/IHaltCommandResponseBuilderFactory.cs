using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IHaltCommandResponseBuilder Factory();
}