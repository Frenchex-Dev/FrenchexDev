using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;

public class BuildCommandRequestBuilder : IBuildCommandRequestBuilder
{
    public BuildCommandRequestBuilder(IBaseCommandRequestBuilder baseBuilder)
    {
        BaseBuilder = baseBuilder;
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IBuildCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}