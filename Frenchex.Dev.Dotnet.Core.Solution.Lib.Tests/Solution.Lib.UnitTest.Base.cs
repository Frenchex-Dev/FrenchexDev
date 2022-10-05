using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Solution.Lib.Tests;

public class SolutionLibUnitTestBase
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
            },
            (services, root) =>
            {
                services.AddScoped<T>();
            });
    }
}