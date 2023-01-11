﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

public class UpCommandRequest : RootCommandRequest, IUpCommandRequest
{
    public UpCommandRequest(
        string[] namesOrIds,
        bool provision,
        string[] provisionWith,
        bool destroyOnError,
        bool parallel,
        string provider,
        bool installProvider,
        bool minimal,
        IBaseCommandRequest baseRequest
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
        Provision = provision;
        ProvisionWith = provisionWith;
        DestroyOnError = destroyOnError;
        Parallel = parallel;
        Provider = provider;
        InstallProvider = installProvider;
        Minimal = minimal;
    }

    public bool Minimal { get; }
    public bool Provision { get; }
    public string[] ProvisionWith { get; }
    public bool DestroyOnError { get; }
    public bool Parallel { get; }
    public string Provider { get; }
    public bool InstallProvider { get; }
    public string[] NamesOrIds { get; }
}