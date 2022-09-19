using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IInitCommand, InitCommand>()
            
            .AddScoped<IInitCommandRequestBuilder, InitCommandRequestBuilder>()
            .AddScoped<IInitCommandRequestBuilderFactory, InitCommandRequestBuilderFactory>()
            
            .AddScoped<IInitCommandResponseBuilder, InitCommandResponseBuilder>()
            .AddScoped<IInitCommandResponseBuilderFactory, InitCommandResponseBuilderFactory>()
            ;
    }
}