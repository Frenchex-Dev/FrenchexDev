#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add.DependecyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDefineMachineTypeAddCommand, DefineMachineTypeAddCommand>()
            .AddScoped<IDefineMachineTypeAddCommandRequestBuilder, DefineMachineTypeAddCommandRequestBuilder>()
            .AddScoped<IDefineMachineTypeAddCommandRequestBuilderFactory,
                DefineMachineTypeAddCommandRequestBuilderFactory>()
            .AddScoped<IDefineMachineTypeAddCommandResponseBuilder, DefineMachineTypeAddCommandResponseBuilder>()
            .AddScoped<IDefineMachineTypeAddCommandResponseBuilderFactory,
                DefineMachineTypeAddCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}