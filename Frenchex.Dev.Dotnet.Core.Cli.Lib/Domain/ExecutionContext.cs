using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class ExecutionContext : IExecutionContext
{
    public AsyncServiceScope AsyncScope { get; init; }

    public IServiceProvider Services => AsyncScope.ServiceProvider;

    public async ValueTask DisposeAsync()
    {
        await AsyncScope.DisposeAsync();
    }
}