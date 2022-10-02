using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

public interface INameCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    INameCommandRequestBuilder Factory();
}