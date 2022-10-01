using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Build.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Build.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Build.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IBuildCommandFacade, BuildCommandFacade>()
            .AddScoped<IBuildCommand, BuildCommand>()
            .AddTransient<IBuildCommandRequest, BuildCommandRequest>()
            .AddScoped<IBuildCommandRequestBuilder, BuildCommandRequestBuilder>()
            .AddScoped<IBuildCommandRequestBuilderFactory, BuildCommandRequestBuilderFactory>()
            .AddTransient<IBuildCommandResponse, BuildCommandResponse>()
            .AddScoped<IBuildCommandResponseBuilder, BuildCommandResponseBuilder>()
            .AddScoped<IBuildCommandResponseBuilderFactory, BuildCommandResponseBuilderFactory>()
            ;
    }
}