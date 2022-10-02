using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

public interface INameCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    INameCommandResponseBuilder Factory();
}