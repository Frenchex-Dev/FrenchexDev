using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Response;

public class UpCommandCommandResponseBuilderFactory : RootCommandResponseBuilderFactory, IUpCommandCommandResponseBuilderFactory
{
    public IUpCommandCommandResponseBuilder Factory()
    {
        return new UpCommandCommandResponseBuilder();
    }
}