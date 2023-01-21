#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Facade;

public class SshCommandFacade : ISshCommandFacade
{
    public SshCommandFacade(ISshCommand command, ISshCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "ssh";
    }

    public ISshCommand Command { get; }
    public ISshCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public ISshCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}