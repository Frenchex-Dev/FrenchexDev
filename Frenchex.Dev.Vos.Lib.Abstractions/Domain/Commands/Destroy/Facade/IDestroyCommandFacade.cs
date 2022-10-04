using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Facade;

public interface IDestroyCommandFacade : IFacableCommand,
    IFacade<IDestroyCommand, IDestroyCommandRequestBuilderFactory, IDestroyCommandRequestBuilder>
{
}