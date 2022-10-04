using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernelBuilder
{
    public Task<IKernel> Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    );
}