using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.Abstractions.Domain.DependencyInjection;

public interface IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection serviceCollection);
}