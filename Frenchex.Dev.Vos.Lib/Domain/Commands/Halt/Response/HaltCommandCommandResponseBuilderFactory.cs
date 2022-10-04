using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IHaltCommandCommandResponseBuilderFactory
{
    public IHaltCommandCommandResponseBuilder Factory()
    {
        return new HaltCommandCommandResponseBuilder();
    }
}