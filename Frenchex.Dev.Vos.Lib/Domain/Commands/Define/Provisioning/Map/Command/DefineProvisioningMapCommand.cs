using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommand : IDefineProvisioningMapCommand
{
    private readonly IDefineProvisioningMapCommandCommandResponseBuilderFactory _commandResponseBuilderFactory;

    public DefineProvisioningMapCommand(
        IDefineProvisioningMapCommandCommandResponseBuilderFactory commandResponseBuilderFactory
    )
    {
        _commandResponseBuilderFactory = commandResponseBuilderFactory;
    }

    public async Task<IDefineProvisioningMapCommandResponse> ExecuteAsync(IDefineProvisioningMapCommandRequest request)
    {
        return await Task.FromResult(_commandResponseBuilderFactory.Factory().Build());
    }
}