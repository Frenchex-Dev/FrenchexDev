#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandCommandRequest : RootCommandRequest, IDefineProvisioningMapCommandRequest
{
    public DefineProvisioningMapCommandCommandRequest() : base()
    {

    }

    public DefineProvisioningMapCommandCommandRequest(
        IBaseCommandRequest baseCommandRequest,
        string[] names,
        string provisioning,
        IDictionary<string, string>? env,
        bool enable,
        bool disable,
        string version,
        bool privileged,
        bool machineType
    ) : base(baseCommandRequest)
    {
        Names = names;
        ProvisioningName = provisioning;
        Env = env;
        Enable = enable;
        Disable = disable;
        Version = version;
        Privileged = privileged;
        MachineType = machineType;
    }

    public string[] Names { get; set; }
    public string ProvisioningName { get; }
    public IDictionary<string, string>? Env { get; }
    public bool Enable { get; set; }
    public bool Disable { get; set; }
    public string Version { get; set; }
    public bool Privileged { get; set; }
    public bool MachineType { get; set; }
}