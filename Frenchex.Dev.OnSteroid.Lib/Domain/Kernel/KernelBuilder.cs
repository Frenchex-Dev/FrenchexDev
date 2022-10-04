using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public class KernelBuilder : IKernelBuilder
{
    private readonly IKernelBuilderBuildingContextFactory _kernelBuilderBuildingContextFactory;

    public KernelBuilder(
        IKernelBuilderBuildingContextFactory kernelBuilderBuildingContextFactory
    )
    {
        _kernelBuilderBuildingContextFactory = kernelBuilderBuildingContextFactory;
    }

    public async Task<IKernel> Build(
        IServiceCollection servicesCollection,
        IKernerlConfiguration kernelConfiguration
    )
    {
        return await Task.Run(() =>
        {
            var buildingContext = _kernelBuilderBuildingContextFactory.Build(servicesCollection, kernelConfiguration);
            var builtKernel = buildingContext.Build();

            return builtKernel;
        });
    }
}