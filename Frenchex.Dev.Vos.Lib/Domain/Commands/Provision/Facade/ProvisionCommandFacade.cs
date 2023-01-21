#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Provision.Facade;

public class ProvisionCommandFacade : IProvisionCommandFacade
{
    public ProvisionCommandFacade(IProvisionCommand command,
        IProvisionCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "up";
    }

    public IProvisionCommand Command { get; }
    public IProvisionCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IProvisionCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}