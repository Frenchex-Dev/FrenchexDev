using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;

public interface IBuildCommandRequestBuilder : IRootCommandRequestBuilder
{
    IBuildCommandRequest Build();
}