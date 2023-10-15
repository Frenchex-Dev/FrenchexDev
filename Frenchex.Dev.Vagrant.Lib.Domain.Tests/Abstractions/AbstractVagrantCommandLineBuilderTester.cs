#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using FluentAssertions;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Tests.Abstractions;

public abstract class AbstractVagrantCommandLineBuilderTester : AbstractFullWorkflowTester
{
    protected async Task ExecuteInternalAsync<TService, TRequest>(
        string                 expected
      , Func<TService, string> action
    ) where TService : IVagrantCommandLineBuilder<TRequest>
      where TRequest : IVagrantCommandRequest
    {
        #region Prepare

        var services = await BuildServiceProviderAsync();

        await using var scope = services.CreateAsyncScope();

        var service = scope.ServiceProvider.GetRequiredService<TService>();

        #endregion

        #region Execute

        var builtCommandLine = action(service);

        #endregion

        #region Asserts

        builtCommandLine
            .Should()
            .BeEquivalentTo(expected, "expected command line arguments generated");

        #endregion
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.ConfigureCommandLineBuilders(services);
        return Task.CompletedTask;
    }
}
