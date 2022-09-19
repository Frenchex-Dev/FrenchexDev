using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IHaltCommand, HaltCommand>()
            .AddScoped<IHaltCommandRequestBuilder, HaltCommandRequestBuilder>()
            .AddScoped<IHaltCommandRequestBuilderFactory, HaltCommandRequestBuilderFactory>()
            .AddScoped<IHaltCommandResponseBuilder, HaltCommandResponseBuilder>()
            .AddScoped<IHaltCommandResponseBuilderFactory, HaltCommandResponseBuilderFactory>()
            ;
    }
}