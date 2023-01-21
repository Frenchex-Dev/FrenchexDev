#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;

public interface IDefineProvisioningMapCommandRequestBuilder : IRootCommandRequestBuilder
{
    IDefineProvisioningMapCommandRequestBuilder UsingNames(string[] names);
    IDefineProvisioningMapCommandRequestBuilder UsingProvisioning(string name);
    IDefineProvisioningMapCommandRequestBuilder UsingEnv(IDictionary<string, string>? env);
    IDefineProvisioningMapCommandRequestBuilder Enabled(bool? enabled);
    IDefineProvisioningMapCommandRequestBuilder Version(string? version);
    IDefineProvisioningMapCommandRequestBuilder Privileged(bool? privileged);
    IDefineProvisioningMapCommandRequestBuilder Machine(bool? machine);
    IDefineProvisioningMapCommandRequestBuilder MachineType(bool? machineType);
    IDefineProvisioningMapCommandRequest Build();
}