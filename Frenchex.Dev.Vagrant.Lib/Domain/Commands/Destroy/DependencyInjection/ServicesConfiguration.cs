using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IDestroyCommand, DestroyCommand>()
            
            .AddScoped<IDestroyCommandFacade, DestroyCommandFacade>()
            
            .AddScoped<IDestroyCommandRequestBuilder, DestroyCommandRequestBuilder>()
            .AddScoped<IDestroyCommandRequestBuilderFactory, DestroyCommandRequestBuilderFactory>()
            
            .AddScoped<IDestroyCommandResponseBuilder, DestroyCommandResponseBuilder>()
            .AddScoped<IDestroyCommandResponseBuilderFactory, DestroyCommandResponseBuilderFactory>()
            ;
    }
}