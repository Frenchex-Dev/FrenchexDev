#region Licensing

// Copyright St�phane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Microsoft.Extensions.Configuration;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IHostConfigurationConfiguration
{
    void Configure(
        IContext context,
        IConfigurationBuilder hostConfiguration
    );
}