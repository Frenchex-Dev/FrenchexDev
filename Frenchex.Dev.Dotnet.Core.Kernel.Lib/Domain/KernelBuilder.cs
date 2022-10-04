using Frenchex.Dev.Dotnet.Core.Kernel.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Kernel.Lib.Domain;

public class KernelBuilder : IKernelBuilder
{
    public async Task<IKernel> BuildAsync(
        IServiceCollection serviceCollection,
        Func<IServiceCollection, Task> dependenciesCollectionFunc
    )
    {
        await dependenciesCollectionFunc.Invoke(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var kernel = new Kernel(serviceProvider);
        return kernel;
    }

    public IKernel Build(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> dependenciesCollectionAction
    )
    {
        dependenciesCollectionAction.Invoke(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var kernel = new Kernel(serviceProvider);
        return kernel;
    }
}