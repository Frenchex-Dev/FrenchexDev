using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Init.Request;

public class InitCommandRequestBuilder : IInitCommandRequestBuilder
{
    public InitCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IInitCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}