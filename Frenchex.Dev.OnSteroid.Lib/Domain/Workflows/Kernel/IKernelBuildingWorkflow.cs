using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Workflows.Kernel;

public interface IKernelBuildingWorkflow
{
    Task<IKernel> FlowAsync(IServiceCollection serviceCollection, IKernerlConfiguration kernelConfiguration);
}