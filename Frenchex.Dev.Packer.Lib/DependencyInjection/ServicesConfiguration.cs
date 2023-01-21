#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Packer.Lib.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        ConfigureExternalDependencies(serviceCollection);

        serviceCollection.AddScoped<ICommandsFacade, CommandsFacade>();

        Domain.Commands.Build.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Console.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Fix.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Fmt.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Hcl2Upgrade.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Init.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Inspect.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Plugins.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
        Domain.Commands.Validate.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);

        return serviceCollection;
    }

    private static void ConfigureExternalDependencies(IServiceCollection serviceCollection)
    {
        Dotnet.Core.Filesystem.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(serviceCollection);

        Dotnet.Core.Process.Lib.DependencyInjection.ServicesConfiguration
            .ConfigureServices(serviceCollection);

        Dotnet.Wrapping.Lib.DependencyInjection.ServicesConfiguration.ConfigureServices(serviceCollection);
    }
}