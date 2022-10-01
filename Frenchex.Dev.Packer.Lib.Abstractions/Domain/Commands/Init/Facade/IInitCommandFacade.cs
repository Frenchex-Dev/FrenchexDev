using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Init.Facade;

public interface IInitCommandFacade : IFacableCommand,
    IFacade<IInitCommand, IInitCommandRequestBuilderFactory, IInitCommandRequestBuilder>
{
}