using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Response;

public interface IInspectCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IInspectCommandResponseBuilder Factory();
}