using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Response;

public interface IDefineProvisioningNewCommandResponseBuilderFactory : IRootResponseBuilderFactory
{
    IDefineProvisioningNewCommandResponseBuilder Factory();
}