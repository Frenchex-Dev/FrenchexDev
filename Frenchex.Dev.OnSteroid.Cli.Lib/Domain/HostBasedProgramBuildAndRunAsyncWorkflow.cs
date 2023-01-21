#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IServicesConfiguration =
    Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection.IServicesConfiguration;

#endregion

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain;

public static class HostBasedProgramBuildAndRunAsyncWorkflow
{
    public static async Task BuildAndRunAsync<T>(
        IServiceCollection serviceCollection,
        IProgramBuilder programBuilder,
        IServicesConfiguration servicesConfiguration,
        Context context
    ) where T : class, IHostedService
    {
        await using IProgram? program = await programBuilder
            .BuildAsync<T>(
                serviceCollection,
                serviceCollection => { servicesConfiguration.ConfigureServices(serviceCollection); },
                context
            );

        await program.RunAsync();
    }
}