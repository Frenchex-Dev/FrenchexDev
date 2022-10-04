using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Response;

public class InitCommandCommandResponseBuilder : RootCommandResponseBuilder, IInitCommandCommandResponseBuilder
{
    public IInitCommandResponse Build()
    {
        return new InitCommandResponse();
    }
}