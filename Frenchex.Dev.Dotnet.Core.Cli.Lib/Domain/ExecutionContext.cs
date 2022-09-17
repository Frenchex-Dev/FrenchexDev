using Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class ExecutionContextBuilder
{
    public ExecutionContext Build()
    {
        IServiceCollection coreServices = new ServiceCollection();
        ServicesConfiguration.StaticConfigureServices(coreServices);
        var coreServicesProvider = coreServices.BuildServiceProvider();

        return new ExecutionContext {AsyncScope = coreServicesProvider.CreateAsyncScope()};
    }
}

public class ExecutionContext : IAsyncDisposable
{
    public AsyncServiceScope AsyncScope { get; init; }

    public IServiceProvider Services => AsyncScope.ServiceProvider;

    public async ValueTask DisposeAsync()
    {
        await AsyncScope.DisposeAsync();
    }
}