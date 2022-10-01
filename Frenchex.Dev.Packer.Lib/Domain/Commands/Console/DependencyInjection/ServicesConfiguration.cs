using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IConsoleCommandFacade, ConsoleCommandFacade>()
            .AddScoped<IConsoleCommand, ConsoleCommand>()
            .AddScoped<IConsoleCommandRequestBuilder, ConsoleCommandRequestBuilder>()
            .AddScoped<IConsoleCommandRequestBuilderFactory, ConsoleCommandRequestBuilderFactory>()
            .AddScoped<IConsoleCommandResponseBuilder, ConsoleCommandResponseBuilder>()
            .AddScoped<IConsoleCommandResponseBuilderFactory, ConsoleCommandResponseBuilderFactory>()
            ;
    }
}