#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandRequestBuilder : IDefineProvisioningMapCommandRequestBuilder
{
    private bool _enable;
    private IDictionary<string, string>? _env;
    private bool _machineType;
    private string[]? _names;
    private bool _privileged;
    private string? _provisioning;
    private string? _version;

    public DefineProvisioningMapCommandRequestBuilder(
        IBaseRequestBuilderFactory baseBuilderFactory
    )
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseRequestBuilder BaseBuilder { get; }


    public IDefineProvisioningMapCommandRequestBuilder Machine(bool? machine)
    {
        _machineType = !machine ?? false;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder MachineType(bool? machineType)
    {
        _machineType = machineType ?? true;
        return this;
    }

    public IDefineProvisioningMapCommandRequest Build()
    {
        if (null == _names) throw new ArgumentNullException(nameof(_names));

        if (string.IsNullOrEmpty(_provisioning)) throw new ArgumentNullException(nameof(_provisioning));

        if (string.IsNullOrEmpty(_version)) throw new ArgumentNullException(nameof(_version));

        return new DefineProvisioningMapCommandCommandRequest(
            BaseBuilder.Build(),
            _names,
            env: _env,
            provisioning: _provisioning,
            enable: _enable,
            disable: !_enable,
            version: _version,
            privileged: _privileged,
            machineType: _machineType
        );
    }

    public IDefineProvisioningMapCommandRequestBuilder Version(string version)
    {
        _version = version;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder Privileged(bool? privileged = true)
    {
        _privileged = privileged ?? true;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder UsingEnv(IDictionary<string, string>? env)
    {
        _env = env;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder Enabled(bool? enabled = true)
    {
        _enable = enabled ?? true;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder UsingNames(string[] names)
    {
        _names = names;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder UsingProvisioning(string provisioning)
    {
        _provisioning = provisioning;
        return this;
    }
}