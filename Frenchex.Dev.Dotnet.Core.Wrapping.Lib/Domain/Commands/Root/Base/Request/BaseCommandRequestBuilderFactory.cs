using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Base.Request;

namespace Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IBaseCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}