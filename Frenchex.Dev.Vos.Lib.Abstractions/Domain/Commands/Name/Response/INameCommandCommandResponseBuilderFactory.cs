using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

public interface INameCommandCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    INameCommandCommandResponseBuilder Factory();
}