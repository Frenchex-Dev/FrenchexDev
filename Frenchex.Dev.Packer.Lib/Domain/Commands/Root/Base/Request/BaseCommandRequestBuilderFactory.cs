using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}