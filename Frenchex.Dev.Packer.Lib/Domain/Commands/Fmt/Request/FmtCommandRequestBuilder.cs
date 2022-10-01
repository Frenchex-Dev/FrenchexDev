using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Request;

public class FmtCommandRequestBuilder : IFmtCommandRequestBuilder
{
    public FmtCommandRequestBuilder(IBaseCommandRequestBuilder baseBuilder)
    {
        BaseBuilder = baseBuilder;
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IFmtCommandRequest Build()
    {
        return new FmtCommandRequest(BaseBuilder.Build());
    }
}