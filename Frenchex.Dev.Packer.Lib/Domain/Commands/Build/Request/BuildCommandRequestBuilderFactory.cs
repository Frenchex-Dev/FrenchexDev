using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;

public class BuildCommandRequestBuilderFactory : IBuildCommandRequestBuilderFactory
{
    private readonly IBaseCommandRequestBuilder _baseCommandRequestBuilder;

    public BuildCommandRequestBuilderFactory(
        IBaseCommandRequestBuilder baseCommandRequestBuilder
    )
    {
        _baseCommandRequestBuilder = baseCommandRequestBuilder;
    }

    public IBuildCommandRequestBuilder Factory()
    {
        return new BuildCommandRequestBuilder(_baseCommandRequestBuilder);
    }
}