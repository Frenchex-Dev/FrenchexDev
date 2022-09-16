namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map;

public class DefineProvisioningMapCommand : IDefineProvisioningMapCommand
{
    private readonly IDefineProvisioningMapCommandResponseBuilderFactory _responseBuilderFactory;

    public DefineProvisioningMapCommand(
        IDefineProvisioningMapCommandResponseBuilderFactory responseBuilderFactory
    )
    {
        _responseBuilderFactory = responseBuilderFactory;
    }

    public async Task<IDefineProvisioningMapCommandResponse> Execute(IDefineProvisioningMapCommandRequest request)
    {
        return await Task.FromResult(_responseBuilderFactory.Factory().Build());
    }
}