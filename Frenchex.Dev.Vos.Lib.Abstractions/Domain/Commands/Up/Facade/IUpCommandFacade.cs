using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Facade;

public interface IUpCommandFacade : IFacableCommand,
    IFacade<IUpCommand, IUpCommandRequestBuilderFactory, IUpCommandRequestBuilder>
{
}