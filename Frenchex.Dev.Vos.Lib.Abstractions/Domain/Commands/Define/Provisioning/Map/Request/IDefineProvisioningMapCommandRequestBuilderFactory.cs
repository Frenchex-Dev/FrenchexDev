using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IDefineProvisioningMapCommandRequestBuilder Factory();
}