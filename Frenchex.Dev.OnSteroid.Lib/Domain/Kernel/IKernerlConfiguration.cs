using Frenchex.Dev.OnSteroid.Lib.Domain.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Domain.Kernel;

public interface IKernerlConfiguration
{
    IServicesConfiguration ServicesConfiguration { get; }
}