using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IUpCommand, UpCommand>()
            .AddScoped<IUpCommandRequestBuilder, UpCommandRequestBuilder>()
            .AddScoped<IUpCommandRequestBuilderFactory, UpCommandRequestBuilderFactory>()
            .AddScoped<IUpCommandResponseBuilder, UpCommandResponseBuilder>()
            .AddScoped<IUpCommandResponseBuilderFactory, UpCommandResponseBuilderFactory>()
            ;
    }
}