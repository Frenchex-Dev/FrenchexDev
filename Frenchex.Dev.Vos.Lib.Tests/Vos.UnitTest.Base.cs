#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vos.Lib.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Tests;

public static class VosUnitTestBase
{
    public static UnitTest CreateUnitTest<T>() where T : class
    {
        return new UnitTest(
            builder =>
            {
                // no need for configuration
            },
            (services, configurationRoot) => { new ServicesConfiguration().ConfigureServices(services); },
            (services, _) =>
            {
                var configurationBuilder = new ConfigurationBuilder();
                var configuration = configurationBuilder.Build();

                services.AddScoped<IConfiguration>(_ => configuration);
                services.AddScoped<T>();
            }
        );
    }
}