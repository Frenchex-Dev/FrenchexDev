// Licensing please read LICENSE.md

using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.DotnetCore.DotnetCore.Generator.Lib.Infrastructure;
public static class ServicesConfigurator
{
    public static void ConfigureServices(
        IServiceCollection services
    )
    {
        Solution.Generator.Lib.ServicesConfigurator.Configure(services);
        Project.Generator.Lib.ServicesConfigurator.Configure(services);
        Template.Generator.Lib.ServicesConfigurator.Configure(services);
    }
}