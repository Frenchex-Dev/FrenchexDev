using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.OnSteroid.Lib.DependencyInjection;

public interface  IServicesConfiguration
{
    public IServiceCollection ConfigureServices(IServiceCollection outterServices);
}

public static class BasicServicesConfiguration
{
    public static IServiceCollection ConfigureServices(
        IServiceCollection services,
        Action configurationBloc
    )
    {
        configurationBloc.Invoke();

        return services;
    }
}