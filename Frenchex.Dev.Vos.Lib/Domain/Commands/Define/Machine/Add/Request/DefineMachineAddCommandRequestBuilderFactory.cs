#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;

public class DefineMachineAddCommandRequestBuilderFactory : IDefineMachineAddCommandRequestBuilderFactory
{
    private readonly IBaseRequestBuilderFactory _baseRequestBuilderFactory;

    public DefineMachineAddCommandRequestBuilderFactory(
        IBaseRequestBuilderFactory baseRequestBuilderFactory
    )
    {
        _baseRequestBuilderFactory = baseRequestBuilderFactory;
    }

    public IDefineMachineAddCommandRequestBuilder Factory()
    {
        return new DefineMachineAddCommandRequestBuilder(_baseRequestBuilderFactory);
    }
}