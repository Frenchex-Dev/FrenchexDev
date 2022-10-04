using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IInitCommandRequestBuilder Factory();
}