using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

namespace Frenchex.Dev.Vos.Lib.Kernel;

public interface IKernelBuilderFlow
{
    Task<IKernel> FlowAsync(IKernerlConfiguration kernelConfiguration);
}