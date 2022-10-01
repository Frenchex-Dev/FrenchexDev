using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

public interface IFixCommandRequestBuilder : IRootCommandRequestBuilder
{
    IFixCommandRequest Build();
}