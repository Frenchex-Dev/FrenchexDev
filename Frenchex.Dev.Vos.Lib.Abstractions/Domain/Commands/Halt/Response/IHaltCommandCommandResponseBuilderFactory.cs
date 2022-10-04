using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;

public interface IHaltCommandCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IHaltCommandCommandResponseBuilder Factory();
}