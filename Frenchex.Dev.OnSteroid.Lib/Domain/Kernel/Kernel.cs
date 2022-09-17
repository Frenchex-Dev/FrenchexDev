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

    private  Func<Task<ServiceProvider>> ServiceProviderBuilder { get; }
    public IKernerlConfiguration Configuration { get; init; }
    

    public Dictionary<string, AsyncServiceScope> Scopes { get; } = new Dictionary<string, AsyncServiceScope>();
    public async Task<AsyncServiceScope> CreateScopeAsync(string name)
    {
        var scope = await ServiceProviderBuilder.Invoke();
        var newScope = scope.CreateAsyncScope();
        Scopes.Add(name, newScope);

        return newScope;
    }

    public async ValueTask DisposeAsync()
    {
        await Task.Run(() =>
        {
            foreach (var scope in Scopes)
            {
                scope.Value.DisposeAsync();
            }
        });
    }
    public void Dispose()
    {
        foreach (var scope in Scopes)
        {
            scope.Value.DisposeAsync();
        }
    }
}

