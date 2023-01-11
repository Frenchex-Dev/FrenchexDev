#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Status.Facade;

public class StatusCommandFacade : IStatusCommandFacade
{
    public StatusCommandFacade(IStatusCommand command, IStatusCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "ssh-config";
    }

    public IStatusCommand Command { get; }
    public IStatusCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IStatusCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}