using Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Kernel;

public interface IKernelBuilderFlow
{
    Task<IKernel> FlowAsync(IServiceCollection services);
}