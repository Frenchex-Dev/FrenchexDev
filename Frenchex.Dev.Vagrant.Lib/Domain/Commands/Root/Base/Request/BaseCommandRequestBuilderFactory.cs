﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;

public class BaseCommandRequestBuilderFactory : IBaseCommandRequestBuilderFactory
{
    public IBaseCommandRequestBuilder Factory(object parent)
    {
        return new BaseCommandRequestBuilder(parent);
    }
}