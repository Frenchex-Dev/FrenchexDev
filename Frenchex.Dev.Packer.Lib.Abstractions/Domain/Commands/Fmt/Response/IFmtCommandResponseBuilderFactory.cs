using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;

public interface IFmtCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IFmtCommandResponseBuilder Factory();
}