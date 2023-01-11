#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IAppConfigurationConfiguration
{
    void ConfigureApp(
        IContext context,
        HostBuilderContext hostContext,
        IConfigurationBuilder appConfiguration
    );
}