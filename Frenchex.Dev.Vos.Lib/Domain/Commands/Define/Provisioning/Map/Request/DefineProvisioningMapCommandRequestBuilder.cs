#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Provisioning.Map.Request;

public class DefineProvisioningMapCommandRequestBuilder : IDefineProvisioningMapCommandRequestBuilder
{
    private IDictionary<string, string>? _env;
    private string[]? _names;
    private string? _version;
    private bool _enable;
    private string? _provisioning;
    private bool _privileged;
    private bool _machineType;

    public DefineProvisioningMapCommandRequestBuilder(
        IBaseRequestBuilderFactory baseBuilderFactory
    )
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseRequestBuilder BaseBuilder { get; }

    public IDefineProvisioningMapCommandRequestBuilder Unprivileged()
    {
        _privileged = false;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder Machine()
    {
        _machineType = false;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder MachineType()
    {
        _machineType = true;
        return this;
    }

    public IDefineProvisioningMapCommandRequest Build()
    {
        if (null == _names)
        {
            throw new ArgumentNullException(nameof(_names));
        }

        if (string.IsNullOrEmpty(_provisioning))
        {
            throw new ArgumentNullException(nameof(_provisioning));
        }

        if (string.IsNullOrEmpty(_version))
        {
            throw new ArgumentNullException(nameof(_version));
        }

        return new DefineProvisioningMapCommandCommandRequest(
            baseCommandRequest: BaseBuilder.Build(),
            names: _names,
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

    public IDefineProvisioningMapCommandRequestBuilder Privileged()
    {
        _privileged = true;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder UsingEnv(IDictionary<string, string>? env)
    {
        _env = env;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder Enable()
    {
        _enable = true;
        return this;
    }

    public IDefineProvisioningMapCommandRequestBuilder Disable()
    {
        _enable = false;
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