#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Init.Facade;

public class InitCommandFacade : IInitCommandFacade
{
    public InitCommandFacade(IInitCommand command, IInitCommandRequestBuilderFactory requestBuilderFactory)
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public string GetCliCommandName()
    {
        return "init";
    }

    public IInitCommand Command { get; }
    public IInitCommandRequestBuilderFactory RequestBuilderFactory { get; }
    public IInitCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();
}