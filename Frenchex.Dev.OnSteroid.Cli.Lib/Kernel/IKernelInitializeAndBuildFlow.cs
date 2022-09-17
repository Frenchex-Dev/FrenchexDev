using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;
using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Kernel;

public interface IKernelInitializeAndBuildFlow
{
    public Task<IKernel> FlowAsync(
        IServiceCollection services,
        IServicesConfiguration servicesConfiguration
    );
}