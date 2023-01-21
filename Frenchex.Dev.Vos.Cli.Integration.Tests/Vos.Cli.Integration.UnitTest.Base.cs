#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vos.Cli.Integration.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

public static class VosCliIntegrationUnitTestBase
{
    public static UnitTest CreateUnitTest<T, TV>()
        where T : class
        where TV : class
    {
        var unitTest = new UnitTest(
            builder =>
            {
                // no need for configuration
            },
            (services, configurationRoot) => { new ServicesConfiguration().ConfigureServices(services); },
            (services, _) =>
            {
                var configurationBuilder = new ConfigurationBuilder();
                IConfigurationRoot? configuration = configurationBuilder.Build();

                var mockedConsole = new Mock<IConsole>();
                services.AddSingleton(_ => mockedConsole.Object);

                services.AddScoped<IConfiguration>(_ => configuration);
                services.AddScoped<T>();
                services.AddScoped<TV>();
            }
        );

        return unitTest;
    }
}