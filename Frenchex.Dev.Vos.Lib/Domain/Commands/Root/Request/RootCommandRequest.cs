﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

public class RootCommandRequest : IRootCommandRequest
{
    public RootCommandRequest()
    {

    }

    public RootCommandRequest(IBaseCommandRequest baseCommand)
    {
        BaseCommand = baseCommand;
    }

    public IBaseCommandRequest BaseCommand { get; }
}