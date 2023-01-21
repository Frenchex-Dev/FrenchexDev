using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Cli.Integration.Domain.Arguments;

public static class DependencyInjectionConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped<IBoxNameArgumentBuilder, BoxNameArgumentBuilder>()
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