using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandRequest : RootRequest, IDefineProvisioningMapCommandRequest
{
    public DefineProvisioningMapCommandRequest(
        IBaseRequest baseRequest,
        string provisioning,
        IDictionary<string, string> env
    ) : base(baseRequest)
    {
        Provisioning = provisioning;
        Env = env;
    }

    public string Provisioning { get; }
    public IDictionary<string, string> Env { get; }
}