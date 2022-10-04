using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.Hosting;

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
        await Task.Run(() =>
        {
            _host.Dispose();
        });
    }

    public void Dispose()
    {
        _host.Dispose();
    }
}