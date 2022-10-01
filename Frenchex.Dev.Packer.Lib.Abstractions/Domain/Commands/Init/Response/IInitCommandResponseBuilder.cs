using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Response;

public interface IInitCommandResponseBuilder : IRootCommandResponseBuilder
{
    IInitCommandResponse Build();
}