#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class Kernel : IKernel
{
    public Kernel(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public IServiceProvider ServiceProvider { get; init; }

    public Dictionary<string, AsyncServiceScope> AsyncScopes { get; init; } = new();

    public Dictionary<string, IServiceScope> Scopes { get; init; } = new();

    public AsyncServiceScope GetOrCreateAsyncScope(string name)
    {
        if (AsyncScopes.ContainsKey(name))
            return AsyncScopes[name];

        AsyncServiceScope newScope = ServiceProvider.CreateAsyncScope();
        AsyncScopes.Add(name, newScope);

        return newScope;
    }

    public IServiceScope GetOrCreateScope(string name)
    {
        if (Scopes.ContainsKey(name))
            return Scopes[name];

        IServiceScope? newScope = ServiceProvider.CreateScope();
        Scopes.Add(name, newScope);

        return newScope;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncScopes();

        DisposeScopes();

        GC.SuppressFinalize(this);
    }

    private void DisposeScopes()
    {
        foreach (var scope in Scopes) scope.Value.Dispose();
    }

    private async ValueTask DisposeAsyncScopes()
    {
        foreach (var scope in AsyncScopes) await scope.Value.DisposeAsync();
    }
}