#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using System.Reflection;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IHostBuilder = Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain.IHostBuilder;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class HostBuilder : IHostBuilder
{
    private readonly IAppConfigurationConfiguration _appConfiguration;
    private readonly IEntrypointInfo _entryPointInfo;
    private readonly IHostConfigurationConfiguration _hostConfiguration;
    private readonly IServicesConfiguration _servicesConfiguration;

    public HostBuilder(
        IEntrypointInfo entrypointInfo,
        IHostConfigurationConfiguration hostConfigurationConfiguration,
        IAppConfigurationConfiguration appConfigurationConfiguration,
        IServicesConfiguration servicesConfiguration
    )
    {
        _entryPointInfo = entrypointInfo;
        _hostConfiguration = hostConfigurationConfiguration;
        _appConfiguration = appConfigurationConfiguration;
        _servicesConfiguration = servicesConfiguration;
    }

    public IHost Build(
        IContext context,
        Action<IServiceCollection> servicesConfigurationLambda,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return BuildInternal(context, loggingConfigurationLambda, servicesConfigurationLambda, null);
    }

    public IHost Build(
        IContext context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfigurationLambda
    )
    {
        return BuildInternal(context, loggingConfigurationLambda, null, asyncServiceScope);
    }

    private IHost BuildInternal(
        IContext context,
        Action<ILoggingBuilder> loggingConfigurationLambda,
        Action<IServiceCollection>? servicesConfigurationLambda,
        AsyncServiceScope? asyncServiceScope
    )
    {
        return Host
                .CreateDefaultBuilder(_entryPointInfo.CommandLineArgs)
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!)
                .ConfigureHostConfiguration(hostConfiguration =>
                {
                    _hostConfiguration.Configure(context, hostConfiguration);
                })
                .ConfigureAppConfiguration((hostContext, appConfiguration) =>
                {
                    _appConfiguration.ConfigureApp(context, hostContext, appConfiguration);
                })
                .ConfigureServices(services =>
                {
                    servicesConfigurationLambda?.Invoke(services);
                    _servicesConfiguration.ConfigureServices(services);
                })
                .ConfigureLogging(loggingConfigurationLambda)
                .Build()
            ;
    }
}