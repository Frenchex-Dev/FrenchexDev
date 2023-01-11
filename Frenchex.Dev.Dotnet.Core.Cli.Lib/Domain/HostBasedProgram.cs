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
using Microsoft.Extensions.Hosting;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class HostBasedProgram : IProgram
{
    private readonly IHost _host;

    public HostBasedProgram(
        IHost host
    )
    {
        _host = host;
    }

    public async Task RunAsync()
    {
        await _host.StartAsync();
        await _host.WaitForShutdownAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await Task.Run(() => { _host.Dispose(); });
    }

    public void Dispose()
    {
        _host.Dispose();
    }
}