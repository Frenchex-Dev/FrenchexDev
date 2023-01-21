#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig.Facade;

public class SshConfigCommandFacade : ISshConfigCommandFacade
{
    public SshConfigCommandFacade(
        ISshConfigCommand command,
        ISshConfigCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "ssh-config";
    }

    public ISshConfigCommand Command { get; }
    public ISshConfigCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public ISshConfigCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}