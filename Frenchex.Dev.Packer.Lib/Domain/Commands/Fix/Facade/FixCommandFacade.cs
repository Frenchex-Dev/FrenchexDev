#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fix.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fix.Facade;

public class FixCommandFacade : IFixCommandFacade
{
    public FixCommandFacade(
        IFixCommand command,
        IFixCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IFixCommand Command { get; }
    public IFixCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IFixCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fix";
    }
}