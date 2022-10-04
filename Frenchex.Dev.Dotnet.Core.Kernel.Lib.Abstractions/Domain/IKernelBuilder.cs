using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Kernel.Lib.Abstractions.Domain;

public interface IKernelBuilder
{
    Task<IKernel> BuildAsync(IServiceCollection serviceCollection, Func<IServiceCollection, Task> dependenciesCollectionFunction);
    IKernel Build(IServiceCollection serviceCollection, Action<IServiceCollection> dependenciesCollectionAction);
}