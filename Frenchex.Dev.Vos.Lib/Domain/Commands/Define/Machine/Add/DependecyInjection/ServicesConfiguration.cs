#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Facade;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.DependecyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDefineMachineAddCommand, DefineMachineAddCommand>()
            .AddScoped<IDefineMachineAddCommandFacade, DefineMachineAddCommandFacade>()
            .AddScoped<IDefineMachineAddCommandRequestBuilder, DefineMachineAddCommandRequestBuilder>()
            .AddScoped<IDefineMachineAddCommandRequestBuilderFactory, DefineMachineAddCommandRequestBuilderFactory>()
            .AddScoped<IDefineMachineAddCommandResponseBuilder, DefineMachineAddCommandResponseBuilder>()
            .AddScoped<IDefineMachineAddCommandResponseBuilderFactory, DefineMachineAddCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}