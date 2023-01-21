#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Kernel.Lib.Abstractions.Domain;

public interface IKernelBuilder
{
    Task<IKernel> BuildAsync(IServiceCollection serviceCollection,
        Func<IServiceCollection, Task> dependenciesCollectionFunction);

    IKernel Build(IServiceCollection serviceCollection, Action<IServiceCollection> dependenciesCollectionAction);
}