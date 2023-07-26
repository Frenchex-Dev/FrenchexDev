#region Usings

using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Infrastructure;

public static class ServicesConfigurator
{
    public static void ConfigureServices(
        IServiceCollection services
    )
    {
        DotnetCore.Process.Lib.ServicesConfigurator.Configure(services);
    }
}
