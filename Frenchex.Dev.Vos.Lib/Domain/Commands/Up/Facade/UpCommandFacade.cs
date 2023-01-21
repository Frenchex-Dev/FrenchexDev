#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Up.Facade;

public class UpCommandFacade : IUpCommandFacade
{
    public UpCommandFacade(IUpCommand command, IUpCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "up";
    }

    public IUpCommand Command { get; }
    public IUpCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IUpCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}