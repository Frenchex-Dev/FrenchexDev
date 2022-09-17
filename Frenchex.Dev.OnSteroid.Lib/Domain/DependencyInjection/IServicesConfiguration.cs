using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.DependencyInjection;

public interface IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection services);
}

