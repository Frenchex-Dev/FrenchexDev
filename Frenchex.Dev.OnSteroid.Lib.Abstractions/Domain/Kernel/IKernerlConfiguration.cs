using Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.Kernel;

public interface IKernerlConfiguration
{
    IServicesConfiguration ServicesConfiguration { get; }
}