#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Facade;

public class FmtCommandFacade : IFmtCommandFacade
{
    public FmtCommandFacade(
        IFmtCommand command,
        IFmtCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IFmtCommand Command { get; }
    public IFmtCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IFmtCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fmt";
    }
}