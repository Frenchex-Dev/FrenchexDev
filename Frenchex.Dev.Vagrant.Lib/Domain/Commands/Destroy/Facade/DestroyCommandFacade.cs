#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Facade;

internal class DestroyCommandFacade : IDestroyCommandFacade
{
    public DestroyCommandFacade(IDestroyCommand command, IDestroyCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IDestroyCommand Command { get; }
    public IDestroyCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IDestroyCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}