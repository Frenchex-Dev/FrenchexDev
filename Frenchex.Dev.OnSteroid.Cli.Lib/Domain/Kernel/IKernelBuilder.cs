using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Kernel;

public interface IKernelBuilder
{
    Task<IKernel> Build(IServiceCollection services);
}