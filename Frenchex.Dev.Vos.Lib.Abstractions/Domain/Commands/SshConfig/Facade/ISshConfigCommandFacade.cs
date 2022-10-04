using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Facade;

public interface ISshConfigCommandFacade : IFacableCommand,
    IFacade<ISshConfigCommand, ISshConfigCommandRequestBuilderFactory, ISshConfigCommandRequestBuilder>
{
}