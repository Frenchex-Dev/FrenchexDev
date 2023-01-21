#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Inspect.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Inspect.Facade;

public class InspectCommandFacade : IInspectCommandFacade
{
    public InspectCommandFacade(
        IInspectCommand command,
        IInspectCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }


    public string GetCliCommandName()
    {
        return "inspect";
    }

    public IInspectCommand Command { get; }
    public IInspectCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IInspectCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}