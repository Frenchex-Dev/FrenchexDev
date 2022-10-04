using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernel : IAsyncDisposable
{
    const string DefaultScopeName = "default";

    IServiceProvider ServiceProvider { get; init; }
    public Dictionary<string, AsyncServiceScope> AsyncScopes { get; init; }
    public Dictionary<string, IServiceScope> Scopes { get; init; }
    AsyncServiceScope GetOrCreateAsyncScope(string name = DefaultScopeName);
    IServiceScope GetOrCreateScope(string name = DefaultScopeName);
}