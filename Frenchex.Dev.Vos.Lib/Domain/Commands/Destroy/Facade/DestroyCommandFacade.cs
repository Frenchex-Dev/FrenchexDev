#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy.Facade;

public class DestroyCommandFacade : IDestroyCommandFacade
{
    public DestroyCommandFacade(IDestroyCommand command, IDestroyCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "destroy";
    }

    public IDestroyCommand Command { get; }
    public IDestroyCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDestroyCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}