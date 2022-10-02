using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add.DependecyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IDefineMachineAddCommand, DefineMachineAddCommand>()
            
            .AddScoped<IDefineMachineAddCommandRequestBuilder, DefineMachineAddCommandRequestBuilder>()
            .AddScoped<IDefineMachineAddCommandRequestBuilderFactory, DefineMachineAddCommandRequestBuilderFactory>()
            
            .AddScoped<IDefineMachineAddCommandResponseBuilder, DefineMachineAddCommandResponseBuilder>()
            .AddScoped<IDefineMachineAddCommandResponseBuilderFactory, DefineMachineAddCommandResponseBuilderFactory>()
            ;

        return serviceCollection;
    }
}