#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

#endregion

namespace Frenchex.Dev.Vos.Cli;

/// <summary>
///     Implements BasicHostedService for this Program
/// </summary>
public class Host : BasicHostedService<Host>
{
    /// <summary>
    ///     Constructor for this Program Host
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="hostApplicationLifetime"></param>
    /// <param name="entryPointInfo"></param>
    /// <param name="integrations"></param>
    public Host(
        ILogger<Host> logger,
        IHostApplicationLifetime hostApplicationLifetime,
        IEntrypointInfo entryPointInfo,
        IEnumerable<IIntegration> integrations
    ) : base("Frenchex.Dev.Vos.Cli", logger, hostApplicationLifetime, entryPointInfo, integrations)
    {
    }
}