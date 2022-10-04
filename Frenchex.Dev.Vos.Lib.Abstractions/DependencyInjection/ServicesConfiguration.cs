using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Abstractions.DependencyInjection;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<MachineBaseDefinitionBuilder, MachineBaseDefinitionBuilder>()
            .AddTransient<MachineBaseDefinitionBuilderFactory, MachineBaseDefinitionBuilderFactory>()
            .AddTransient<MachineDefinitionBuilder, MachineDefinitionBuilder>()
            .AddTransient<MachineDefinitionBuilderFactory, MachineDefinitionBuilderFactory>()
            .AddTransient<IMachineTypeDefinitionBuilder, MachineTypeDefinitionBuilder>()
            .AddTransient<IMachineTypeDefinitionBuilderFactory, MachineTypeDefinitionBuilderFactory>()
            ;

        return serviceCollection;
    }
}