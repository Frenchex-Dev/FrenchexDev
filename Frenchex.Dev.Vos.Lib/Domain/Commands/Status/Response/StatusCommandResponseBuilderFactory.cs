using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;

public class StatusCommandResponseBuilderFactory : IStatusCommandResponseBuilderFactory
{
    public IStatusCommandResponseBuilder Factory()
    {
        return new StatusCommandResponseBuilder();
    }
}