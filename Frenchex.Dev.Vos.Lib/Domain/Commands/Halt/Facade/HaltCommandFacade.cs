#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Halt.Facade;

public class HaltCommandFacade : IHaltCommandFacade
{
    public HaltCommandFacade(IHaltCommand command, IHaltCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "halt";
    }

    public IHaltCommand Command { get; }
    public IHaltCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IHaltCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}