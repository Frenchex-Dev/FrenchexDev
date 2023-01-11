#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Lib.Kernel;

public interface IKernelInitializeAndBuildFlow
{
    public Task<IKernel> FlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    );
}