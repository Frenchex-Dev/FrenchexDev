using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Facade;

public interface IInitCommandFacade : IFacableCommand,
    IFacade<IInitCommand, IInitCommandRequestBuilderFactory, IInitCommandRequestBuilder>
{
}