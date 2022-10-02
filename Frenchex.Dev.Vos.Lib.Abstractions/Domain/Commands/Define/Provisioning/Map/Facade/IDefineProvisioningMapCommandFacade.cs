using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Facade;

public interface IDefineProvisioningMapCommandFacade : IFacableCommand,
    Domain.IFacade<IDefineProvisioningMapCommand, IDefineProvisioningMapCommandRequestBuilderFactory,
        IDefineProvisioningMapCommandRequestBuilder>
{
}