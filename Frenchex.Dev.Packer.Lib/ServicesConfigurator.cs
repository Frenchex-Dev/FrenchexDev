#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib;

public static class ServicesConfigurator
{
    public static void Configure(
        IServiceCollection services
    )
    {
        Infrastructure.ServicesConfigurator.ConfigureServices(services);
    }
}
