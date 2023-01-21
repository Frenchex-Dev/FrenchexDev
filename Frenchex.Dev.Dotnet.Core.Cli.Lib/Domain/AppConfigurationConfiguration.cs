#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class AppConfigurationConfiguration : IAppConfigurationConfiguration
{
    private readonly IEntrypointInfo _entrypointInfo;

    public AppConfigurationConfiguration(
        IEntrypointInfo entrypointInfo
    )
    {
        _entrypointInfo = entrypointInfo;
    }

    public void ConfigureApp(
        IContext context,
        HostBuilderContext hostContext,
        IConfigurationBuilder appConfiguration
    )
    {
        appConfiguration.SetBasePath(context.BasePath);
        appConfiguration.AddJsonFile(context.AppSettings, true);
        appConfiguration.AddJsonFile(
            $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
            true
        );

        appConfiguration.AddEnvironmentVariables(context.EnvVarPrefix);
        appConfiguration.AddCommandLine(_entrypointInfo.CommandLineArgs);
    }
}