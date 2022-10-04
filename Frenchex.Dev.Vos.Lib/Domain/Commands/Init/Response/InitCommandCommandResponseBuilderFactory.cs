using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Response;

public class InitCommandCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IInitCommandCommandResponseBuilderFactory
{
    public IInitCommandCommandResponseBuilder Factory()
    {
        return new InitCommandCommandResponseBuilder();
    }
}