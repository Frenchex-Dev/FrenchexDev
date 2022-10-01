using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Request;

public class FixCommandRequestBuilder : IFixCommandRequestBuilder
{
    public FixCommandRequestBuilder(IBaseCommandRequestBuilder baseBuilder)
    {
        BaseBuilder = baseBuilder;
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IFixCommandRequest Build()
    {
        return new FixCommandRequest(BaseBuilder.Build());
    }
}