using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Command;

public interface
    IDefineProvisioningNewCommand : IAsyncRootCommand<IDefineProvisioningNewCommandRequest,
        IDefineProvisioningNewCommandResponse>
{
}