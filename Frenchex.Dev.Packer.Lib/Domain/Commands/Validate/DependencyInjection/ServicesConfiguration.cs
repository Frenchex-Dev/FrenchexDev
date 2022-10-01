using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Facade;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IValidateCommand, ValidateCommand>()
            .AddScoped<IValidateCommandFacade, ValidateCommandFacade>()
            .AddScoped<IValidateCommandRequestBuilder, ValidateCommandRequestBuilder>()
            .AddScoped<IValidateCommandRequestBuilderFactory, ValidateCommandRequestBuilderFactory>()
            .AddScoped<IValidateCommandResponseBuilder, ValidateCommandResponseBuilder>()
            .AddScoped<IValidateCommandResponseBuilderFactory, ValidateCommandResponseBuilderFactory>()
            ;
    }
}