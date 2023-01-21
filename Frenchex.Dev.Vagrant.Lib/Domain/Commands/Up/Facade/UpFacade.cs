#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Facade;

public class UpFacade : IUpFacade
{
    public UpFacade(IUpCommand command, IUpCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IUpCommand Command { get; }
    public IUpCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IUpCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}