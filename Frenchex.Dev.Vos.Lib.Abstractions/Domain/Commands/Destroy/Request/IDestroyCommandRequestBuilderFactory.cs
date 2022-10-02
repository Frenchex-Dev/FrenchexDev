using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

public interface IDestroyCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDestroyCommandRequestBuilder Factory();
}