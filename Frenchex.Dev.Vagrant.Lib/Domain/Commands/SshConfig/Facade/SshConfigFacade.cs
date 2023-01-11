#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Facade;

public class SshConfigFacade : ISshConfigFacade
{
    public SshConfigFacade(ISshConfigCommand command, ISshConfigCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public ISshConfigCommand Command { get; }
    public ISshConfigCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public ISshConfigCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}