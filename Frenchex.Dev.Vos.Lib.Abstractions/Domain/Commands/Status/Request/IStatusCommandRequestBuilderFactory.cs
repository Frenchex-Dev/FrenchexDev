using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IStatusCommandRequestBuilder Factory();
}