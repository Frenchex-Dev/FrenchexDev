using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.DependencyInjection;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Process.Lib.Tests.Domain;

public static class ProcessUnitTestBase
{
    public static UnitTest CreateNewUnitTest<T>() where T : class
    {
        return new UnitTest(
            builder =>
            {
                // no need for a configuration
            },
            (services, root) =>
            {
                ServicesConfiguration
                    .ConfigureServices(services);

                DependencyInjection.ServicesConfiguration.ConfigureServices(services);
            },
            (services, root) =>
            {
                services.AddScoped<T>();
            });
    }
}