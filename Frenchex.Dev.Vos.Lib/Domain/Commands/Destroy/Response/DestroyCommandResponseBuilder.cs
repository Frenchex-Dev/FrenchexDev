using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandResponseBuilder : RootResponseBuilder, IDestroyCommandResponseBuilder
{
    public IDestroyCommandResponse Build()
    {
        return new DestroyCommandResponse();
    }
}