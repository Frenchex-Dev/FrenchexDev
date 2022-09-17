using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface IKernel : IAsyncDisposable
{
    IKernerlConfiguration Configuration { get; }
    Dictionary<string, AsyncServiceScope> Scopes { get; }

    Task<AsyncServiceScope> CreateScopeAsync(string name);
}