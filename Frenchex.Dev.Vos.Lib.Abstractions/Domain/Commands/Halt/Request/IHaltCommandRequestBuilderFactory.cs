using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IHaltCommandRequestBuilder Factory();
}