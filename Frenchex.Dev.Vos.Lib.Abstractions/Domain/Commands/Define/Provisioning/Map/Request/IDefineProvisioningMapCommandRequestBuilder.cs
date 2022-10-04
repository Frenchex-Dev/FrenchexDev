using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineProvisioningMapCommandRequestBuilder UsingProvisioning(string name);
    IDefineProvisioningMapCommandRequestBuilder UsingEnv(Dictionary<string, string> env);
    IDefineProvisioningMapCommandRequest Build();
}