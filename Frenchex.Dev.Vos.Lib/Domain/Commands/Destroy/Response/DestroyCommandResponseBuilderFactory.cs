using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Response;

public class DestroyCommandResponseBuilderFactory : RootResponseBuilderFactory, IDestroyCommandResponseBuilderFactory
{
    public IDestroyCommandResponseBuilder Build()
    {
        return new DestroyCommandResponseBuilder();
    }
}