﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;

public class DefineMachineTypeAddCommandRequestBuilderFactory : IDefineMachineTypeAddCommandRequestBuilderFactory
{
    private readonly IBaseRequestBuilderFactory _baseRequestBuilderFactory;

    public DefineMachineTypeAddCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseRequestBuilderFactory = baseRequestBuilderFactory;
    }

    public IDefineMachineTypeAddCommandRequestBuilder Factory()
    {
        return new DefineMachineTypeAddCommandRequestBuilder(_baseRequestBuilderFactory);
    }
}