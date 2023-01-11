#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class HostConfigurationConfiguration : IHostConfigurationConfiguration
{
    private readonly IEntrypointInfo _entrypointInfo;

    public HostConfigurationConfiguration(
        IEntrypointInfo entrypointInfo
    )
    {
        _entrypointInfo = entrypointInfo;
    }

    public void Configure(
        IContext context,
        IConfigurationBuilder hostConfiguration
    )
    {
        hostConfiguration
            .SetBasePath(context.BasePath)
            .AddJsonFile(context.HostSettings, true)
            .AddEnvironmentVariables(context.EnvVarPrefix)
            .AddCommandLine(_entrypointInfo.CommandLineArgs)
            ;
    }
}