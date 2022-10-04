using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

public interface IHaltCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IHaltCommandRequestBuilder Factory();
}