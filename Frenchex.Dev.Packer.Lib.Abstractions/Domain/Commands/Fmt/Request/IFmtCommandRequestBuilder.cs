using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

public interface IFmtCommandRequestBuilder : IRootCommandRequestBuilder
{
    IFmtCommandRequest Build();
}