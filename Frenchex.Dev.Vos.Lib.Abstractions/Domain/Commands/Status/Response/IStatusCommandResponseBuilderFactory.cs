using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

public interface IStatusCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IStatusCommandResponseBuilder Factory();
}