using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Name.Response;

public class NameCommandCommandResponseBuilderFactory : INameCommandCommandResponseBuilderFactory
{
    public INameCommandCommandResponseBuilder Factory()
    {
        return new NameCommandCommandResponseBuilder();
    }
}