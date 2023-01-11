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

namespace Frenchex.Dev.Dotnet.Core.Kernel.Lib.Abstractions.Domain;

public interface IKernel : IAsyncDisposable
{
    IServiceProvider ServiceProvider { get; init; }
    public Dictionary<string, AsyncServiceScope> AsyncScopes { get; init; }
    public Dictionary<string, IServiceScope> Scopes { get; init; }
    AsyncServiceScope GetOrCreateAsyncScope(string name);
    IServiceScope GetOrCreateScope(string name);
}