using Frenchex.Dev.Dotnet.Core.Kernel.Lib.Abstractions.Domain;
using Frenchex.Dev.Dotnet.Core.Kernel.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Kernel.Lib.DependencyInjection;

public static class ServicesConfiguration
{
    public static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IKernelBuilder, KernelBuilder>()
            ;
    }
}