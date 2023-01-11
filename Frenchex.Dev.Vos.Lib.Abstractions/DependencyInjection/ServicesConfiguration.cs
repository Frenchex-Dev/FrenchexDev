#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Microsoft.Extensions.DependencyInjection;

#endregion

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