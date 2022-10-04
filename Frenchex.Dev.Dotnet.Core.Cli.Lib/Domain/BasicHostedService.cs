using Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class BasicHostedService<T> : AbstractHostedService where T : AbstractHostedService
{
    private readonly string _rootCommandDescription;

    public BasicHostedService(
        string rootCommandDescription,
        ILogger<T> logger,
        IHostApplicationLifetime hostApplicationLifetime,
        IEntrypointInfo entryPointInfo,
        IEnumerable<IIntegration> integrations
    ) : base(logger, hostApplicationLifetime, entryPointInfo, integrations)
    {
        _rootCommandDescription = rootCommandDescription;
    }

    protected override string GetRootCommandDescription()
    {
        return _rootCommandDescription;
    }

    protected override Task OnStarted()
    {
        return ExecuteAsync();
    }

    protected override void OnStopped()
    {
    }

    protected override void OnStopping()
    {
    }
}