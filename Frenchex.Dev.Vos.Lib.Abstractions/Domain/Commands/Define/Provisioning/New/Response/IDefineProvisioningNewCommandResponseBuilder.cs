using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.New.Response;

public interface IDefineProvisioningNewCommandResponseBuilder : IRootResponseBuilder
{
    IDefineProvisioningNewCommandResponse Build();
}