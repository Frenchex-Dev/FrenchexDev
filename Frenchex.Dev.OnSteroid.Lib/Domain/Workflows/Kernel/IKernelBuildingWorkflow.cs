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

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;

public interface IKernelBuildingWorkflow
{
    Task<IKernel> FlowAsync(IServiceCollection serviceCollection, IKernerlConfiguration kernelConfiguration);
}