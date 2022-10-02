using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Response;

public class InitCommandResponseBuilderFactory : RootResponseBuilderFactory, IInitCommandResponseBuilderFactory
{
    public IInitCommandResponseBuilder Factory()
    {
        return new InitCommandResponseBuilder();
    }
}