#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public static class DependencyInjectionConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IBoxNameArgumentBuilder, BoxNameArgumentBuilder>()
            .AddScoped<IBoxVersionArgumentBuilder, BoxVersionArgumentBuilder>()
            .AddScoped<IInstancesArgumentBuilder, InstancesArgumentBuilder>()
            .AddScoped<IMachineTypeNameArgumentBuilder, MachineTypeNameArgumentBuilder>()
            .AddScoped<INameArgumentBuilder, NameArgumentBuilder>()
            .AddScoped<INamesArgumentBuilder, NamesArgumentBuilder>()
            .AddScoped<IOsTypeArgumentBuilder, OsTypeArgumentBuilder>()
            .AddScoped<IOsVersionArgumentBuilder, OsVersionArgumentBuilder>()
            .AddScoped<IParallelOptionBuilder, ParallelOptionBuilder>()
            .AddScoped<IProvisionNameArgumentBuilder, ProvisionNameArgumentBuilder>()
            .AddScoped<IRamMbArgumentBuilder, RamMbArgumentBuilder>()
            .AddScoped<IVersionArgumentBuilder, VersionArgumentBuilder>()
            .AddScoped<IVirtualCpusArgumentBuilder, VirtualCpusArgumentBuilder>()
            ;
    }
}