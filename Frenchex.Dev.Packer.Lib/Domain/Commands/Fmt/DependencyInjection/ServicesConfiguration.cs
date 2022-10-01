using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Fmt.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IFmtCommand, FmtCommand>()
            .AddScoped<IFmtCommandFacade, FmtCommandFacade>()
            .AddScoped<IFmtCommandRequestBuilder, FmtCommandRequestBuilder>()
            .AddScoped<IFmtCommandRequestBuilderFactory, FmtCommandRequestBuilderFactory>()
            .AddScoped<IFmtCommandResponseBuilder, IFmtCommandResponseBuilder>()
            .AddScoped<IFmtCommandResponseBuilderFactory, IFmtCommandResponseBuilderFactory>()
            ;
    }
}