using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Response;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IProvisionCommand, ProvisionCommand>()
            
            .AddScoped<IProvisionCommandRequestBuilder, ProvisionCommandRequestBuilder>()
            .AddScoped<IProvisionCommandRequestBuilderFactory, ProvisionCommandRequestBuilderFactory>()
            
            .AddScoped<IProvisionCommandResponseBuilder, ProvisionCommandResponseBuilder>()
            .AddScoped<IProvisionCommandResponseBuilderFactory, ProvisionCommandResponseBuilderFactory>()
            
            ;
    }
}