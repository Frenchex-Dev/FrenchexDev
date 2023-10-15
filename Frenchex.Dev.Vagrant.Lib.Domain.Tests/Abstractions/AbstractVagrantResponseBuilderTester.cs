#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Testing.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

public abstract class AbstractVagrantResponseBuilderTester : AbstractFullWorkflowTester
{
    protected async Task ExecuteInternalAsync<TService, TResponse>(
        Func<TService, Task<TResponse>> action
      , Action<TResponse>               assert
    ) where TService : IVagrantResponseBuilder<TResponse>
      where TResponse : IVagrantCommandResponse
    {
        #region Prepare

        var services = await BuildServiceProviderAsync();

        await using var scope = services.CreateAsyncScope();

        var service = scope.ServiceProvider.GetRequiredService<TService>();

        #endregion

        #region Execute

        var builtResponse = await action(service);

        #endregion

        #region Asserts

        assert(builtResponse);

        #endregion
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.ConfigureResponseBuilders(services);
        return Task.CompletedTask;
    }

    public class Payload
    {
        public required IList<string>           StdOut   { get; set; }
        public required IList<string>           StdErr   { get; set; }
        public required int                     ExitCode { get; set; }
        public required IVagrantCommandResponse ExpectedResponse { get; set; }
    }
}
