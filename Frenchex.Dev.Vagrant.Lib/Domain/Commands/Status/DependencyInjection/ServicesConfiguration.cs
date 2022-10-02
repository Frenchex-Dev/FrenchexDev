using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IStatusCommand, StatusCommand>()
            .AddScoped<IStatusFacade, StatusFacade>()
            .AddScoped<IStatusCommandRequestBuilder, StatusCommandRequestBuilder>()
            .AddScoped<IStatusCommandRequestBuilderFactory, StatusCommandRequestBuilderFactory>()
            .AddScoped<IStatusCommandResponseBuilder, StatusCommandResponseBuilder>()
            .AddScoped<IStatusCommandResponseBuilderFactory, StatusCommandResponseBuilderFactory>()
            ;
    }
}