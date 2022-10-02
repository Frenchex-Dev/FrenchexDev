using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class Kernel : IKernel, IAsyncDisposable, IDisposable
{
    public Kernel(
        Func<Task<ServiceProvider>> serviceProviderBuilder,
        IKernerlConfiguration configuration
    )
    {
        ServiceProviderBuilder = serviceProviderBuilder;
        Configuration = configuration;
    }

    private Func<Task<ServiceProvider>> ServiceProviderBuilder { get; }

    public void Dispose()
    {
        foreach (KeyValuePair<string, AsyncServiceScope> scope in Scopes)
        {
            scope.Value.DisposeAsync();
        }
    }

    public IKernerlConfiguration Configuration { get; init; }


    public Dictionary<string, AsyncServiceScope> Scopes { get; } = new();

    public async Task<AsyncServiceScope> CreateScopeAsync(string name)
    {
        var serviceProvider = await ServiceProviderBuilder.Invoke();
        var newScope = serviceProvider.CreateAsyncScope();
        Scopes.Add(name, newScope);

        return newScope;
    }

    public async ValueTask DisposeAsync()
    {
        await Task.Run(() =>
        {
            foreach (KeyValuePair<string, AsyncServiceScope> scope in Scopes)
            {
                scope.Value.DisposeAsync();
            }
        });
    }
}