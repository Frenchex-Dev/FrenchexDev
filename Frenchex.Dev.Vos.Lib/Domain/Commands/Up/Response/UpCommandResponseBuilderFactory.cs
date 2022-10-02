using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;

public class UpCommandResponseBuilderFactory : RootResponseBuilderFactory, IUpCommandResponseBuilderFactory
{
    public IUpCommandResponseBuilder Factory()
    {
        return new UpCommandResponseBuilder();
    }
}