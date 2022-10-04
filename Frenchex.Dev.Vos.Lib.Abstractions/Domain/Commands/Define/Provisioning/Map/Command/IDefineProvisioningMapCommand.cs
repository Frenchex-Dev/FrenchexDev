using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Command;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;

public interface
    IDefineProvisioningMapCommand : IAsyncCommand, IAsyncRootCommand<IDefineProvisioningMapCommandRequest,
        IDefineProvisioningMapCommandResponse>
{
}