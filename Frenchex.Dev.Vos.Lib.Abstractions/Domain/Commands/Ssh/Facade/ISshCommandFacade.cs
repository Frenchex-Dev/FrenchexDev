using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;

public interface ISshCommandFacade : IFacableCommand,
    IFacade<ISshCommand, ISshCommandRequestBuilderFactory, ISshCommandRequestBuilder>
{
}