#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;

public class StatusCommandRequest : RootCommandRequest, IStatusCommandRequest
{
    public StatusCommandRequest(
        IBaseCommandRequest baseRequest,
        string[] namesOrIds
    ) : base(baseRequest)
    {
        NamesOrIds = namesOrIds;
    }

    public string[] NamesOrIds { get; }
}