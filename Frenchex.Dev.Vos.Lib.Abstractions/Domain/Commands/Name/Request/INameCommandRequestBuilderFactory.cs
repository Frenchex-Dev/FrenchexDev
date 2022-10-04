using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

public interface INameCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    INameCommandRequestBuilder Factory();
}