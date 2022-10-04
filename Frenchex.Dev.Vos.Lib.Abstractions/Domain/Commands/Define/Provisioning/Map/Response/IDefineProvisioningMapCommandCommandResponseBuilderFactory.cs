using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Response;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Response;

public interface IDefineProvisioningMapCommandCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IDefineProvisioningMapCommandCommandResponseBuilder Factory();
}