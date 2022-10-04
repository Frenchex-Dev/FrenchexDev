using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDefineProvisioningMapCommandRequestBuilder Factory();
}