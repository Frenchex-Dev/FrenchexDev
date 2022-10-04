using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class ExecutionContextBuilder : IExecutionContextBuilder
{
    public IExecutionContext Build()
    {
        IServiceCollection coreServices = new ServiceCollection();
        ServicesConfiguration.StaticConfigureServices(coreServices);
        var coreServicesProvider = coreServices.BuildServiceProvider();

        return new ExecutionContext {AsyncScope = coreServicesProvider.CreateAsyncScope()};
    }
}