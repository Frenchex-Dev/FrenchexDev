using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface  IKernelBuilderBuildingContext
{
    IKernel Build();
}