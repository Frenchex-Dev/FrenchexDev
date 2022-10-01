using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

public interface IInspectCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IInspectCommandRequestBuilder Factory();
}