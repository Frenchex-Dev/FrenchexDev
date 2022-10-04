using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Response;

public class HaltCommandResponseBuilderFactory : RootResponseBuilderFactory, IHaltCommandResponseBuilderFactory
{
    public IHaltCommandResponseBuilder Factory()
    {
        return new HaltCommandResponseBuilder();
    }
}