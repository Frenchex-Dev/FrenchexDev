using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandCommandRequest : RootCommandRequest, IDefineProvisioningMapCommandRequest
{
    public DefineProvisioningMapCommandCommandRequest(
        IBaseCommandRequest baseCommandRequest,
        string provisioning,
        IDictionary<string, string> env
    ) : base(baseCommandRequest)
    {
        Provisioning = provisioning;
        Env = env;
    }

    public string Provisioning { get; }
    public IDictionary<string, string> Env { get; }
}