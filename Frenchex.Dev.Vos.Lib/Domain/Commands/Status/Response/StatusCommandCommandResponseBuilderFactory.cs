using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Response;

public class StatusCommandCommandResponseBuilderFactory : IStatusCommandCommandResponseBuilderFactory
{
    public IStatusCommandCommandResponseBuilder Factory()
    {
        return new StatusCommandCommandResponseBuilder();
    }
}