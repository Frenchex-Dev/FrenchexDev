using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface IKernel : IAsyncDisposable
{
    const string DefaultScopeName = "default";
    
    IKernerlConfiguration Configuration { get; }
    Dictionary<string, AsyncServiceScope> Scopes { get; }

    Task<AsyncServiceScope> CreateScopeAsync(string name = DefaultScopeName);
}