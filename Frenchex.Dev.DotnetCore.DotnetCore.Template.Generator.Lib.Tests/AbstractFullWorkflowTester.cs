using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Tests;

public abstract class AbstractFullWorkflowTester
{
    public async Task<ServiceProvider> BuildServiceProviderAsync(
        CancellationToken cancellationToken = default
    )
    {
        var serviceCollection = new ServiceCollection();
        await ConfigureServicesAsync(serviceCollection, cancellationToken);
        return serviceCollection.BuildServiceProvider(new ServiceProviderOptions
                                                      {
                                                          ValidateOnBuild = true
                                                        , ValidateScopes  = true
                                                      });
    }

    protected abstract Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    );

    public async Task RunScopedAsync(
        ServiceProvider                                  services
      , Func<AsyncServiceScope, CancellationToken, Task> bizFunc
      , CancellationToken                                cancellationToken = default
    )
    {
        await using var scope = services.CreateAsyncScope();
        await bizFunc(scope, cancellationToken);
    }


    public async Task<T> RunScopedAsync<T>(
        ServiceProvider                                     services
      , Func<AsyncServiceScope, CancellationToken, Task<T>> bizFunc
      , CancellationToken                                   cancellationToken = default
    )
    {
        await using var scope = services.CreateAsyncScope();
        var             r     = await bizFunc(scope, cancellationToken);
        return r;
    }
}
