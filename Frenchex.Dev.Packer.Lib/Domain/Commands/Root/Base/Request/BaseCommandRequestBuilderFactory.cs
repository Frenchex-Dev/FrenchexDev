
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}