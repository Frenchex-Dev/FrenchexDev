#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Facade;

public class SshFacade : ISshFacade
{
    public SshFacade(ISshCommand command, ISshCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public ISshCommand Command { get; }
    public ISshCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public ISshCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}