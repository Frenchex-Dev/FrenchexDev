#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

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