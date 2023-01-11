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

public interface IKernelBuilder
{
    public Task<IKernel> Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    );
}