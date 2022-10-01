using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IInitCommandRequestBuilder Factory();
}