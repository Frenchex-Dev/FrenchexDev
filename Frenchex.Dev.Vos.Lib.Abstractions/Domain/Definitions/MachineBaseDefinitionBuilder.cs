﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;

public class MachineBaseDefinitionBuilder
{
    private string? _biosLogoImage;
    private string? _box;
    private string? _boxVersion;

    private bool? _enable3D;

    private bool? _enabled;

    private Dictionary<string, FileCopyDefinition>? _files;

    private bool? _gui;

    private OsTypeEnum? _osType;

    private string? _osVersion;

    private bool? _pageFusion;
    private object? _parent;

    private ProviderEnum? _provider;

    private Dictionary<string, ProvisioningDefinition>? _provisioning;

    private int? _ramInMb;

    private Dictionary<string, SharedFolderDefinition>? _sharedFolders;

    private int? _vcpus;

    private int? _videoRamInMb;

    public MachineBaseDefinitionBuilder SetParent<T>(T parent)
    {
        _parent = parent;
        return this;
    }

    public T Parent<T>()
    {
        if (null == _parent) throw new InvalidOperationException("parent is null");

        return (T)_parent;
    }

    public MachineBaseDefinitionDeclaration Build()
    {
        if (_ramInMb == 0) throw new Exception("RAM cannot be 0");

        return new MachineBaseDefinitionDeclaration
        {
            BiosLogoImagePath = _biosLogoImage,
            Box = _box,
            BoxVersion = _boxVersion,
            Enable3D = _enable3D,
            Enabled = _enabled,
            Files = _files,
            Gui = _gui,
            OsType = _osType,
            OsVersion = _osVersion,
            PageFusion = _pageFusion,
            Provider = _provider,
            VirtualCpus = _vcpus,
            RamInMb = _ramInMb,
            VideoRamInMb = _videoRamInMb,
            SharedFolders = _sharedFolders,
            Provisioning = _provisioning
        };
    }

    public MachineBaseDefinitionBuilder Enabled(bool? enabled)
    {
        _enabled = enabled;
        return this;
    }

    public MachineBaseDefinitionBuilder With3DEnabled(bool? enabled)
    {
        _enable3D = enabled;
        return this;
    }

    public MachineBaseDefinitionBuilder WithBiosLogoImage(string? path)
    {
        _biosLogoImage = path;
        return this;
    }

    public MachineBaseDefinitionBuilder WithBox(string? box)
    {
        _box = box;
        return this;
    }

    public MachineBaseDefinitionBuilder WithFiles(Dictionary<string, FileCopyDefinition>? files)
    {
        _files = files ?? throw new ArgumentNullException(nameof(files));
        return this;
    }

    public MachineBaseDefinitionBuilder WithGui(bool? enabled)
    {
        _gui = enabled;
        return this;
    }

    public MachineBaseDefinitionBuilder WithOsType(OsTypeEnum? type)
    {
        _osType = type;
        return this;
    }

    public MachineBaseDefinitionBuilder WithOsVersion(string? version)
    {
        _osVersion = version;
        return this;
    }

    public MachineBaseDefinitionBuilder WithPageFusion(bool? enabled)
    {
        _pageFusion = enabled;
        return this;
    }

    public MachineBaseDefinitionBuilder WithProvider(ProviderEnum? provider)
    {
        _provider = provider;
        return this;
    }

    public MachineBaseDefinitionBuilder WithProvider(string? provider)
    {
        Enum.TryParse(provider, true, out ProviderEnum parsed);
        _provider = parsed;
        return this;
    }

    public MachineBaseDefinitionBuilder WithProvisioning(Dictionary<string, ProvisioningDefinition>? provisioning)
    {
        _provisioning = provisioning;
        return this;
    }

    public MachineBaseDefinitionBuilder WithRamInMb(int? ramInMb)
    {
        _ramInMb = ramInMb;
        return this;
    }

    public MachineBaseDefinitionBuilder WithSharedFolders(Dictionary<string, SharedFolderDefinition>? sharedFolders)
    {
        _sharedFolders = sharedFolders;
        return this;
    }

    public MachineBaseDefinitionBuilder WithVideoRamInMb(int? videoRamInMb)
    {
        _videoRamInMb = videoRamInMb;
        return this;
    }

    public MachineBaseDefinitionBuilder WithVirtualCpus(int? vcpus)
    {
        _vcpus = vcpus;
        return this;
    }

    public MachineBaseDefinitionBuilder WithBoxVersion(string? version)
    {
        _boxVersion = version;
        return this;
    }
}