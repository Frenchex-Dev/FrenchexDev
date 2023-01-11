#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Kernel;

public class WorkflowBasedKernelBuilder : IKernelBuilder
{
    private readonly IKernelBuildingWorkflow _kernelBuildingWorkflow;

    public WorkflowBasedKernelBuilder(
        IKernelBuildingWorkflow kernelBuildingWorkflow
    )
    {
        _kernelBuildingWorkflow = kernelBuildingWorkflow;
    }

    public async Task<IKernel> Build(IServiceCollection services)
    {
        var servicesConfiguration = new ServicesConfiguration();
        var kernelConfiguration = new KernelConfiguration(servicesConfiguration);

        return await _kernelBuildingWorkflow.FlowAsync(services, kernelConfiguration);
    }
}