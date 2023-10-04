#region Usings

using System.Reflection;
using FluentAssertions;
using Frenchex.Dev.DotnetCore.DotnetCore.Testing.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests;

public class Tests : AbstractFullWorkflowTester
{
    protected static IEnumerable<object[]> WorkflowData()
    {
        yield return new object[]
                     {
                         new VagrantInitRequestBuilder().WithName("generic/alpine317")
                                                        .WithTemplate(Path.Join(Path.GetDirectoryName(Assembly
                                                                                                      .GetCallingAssembly()
                                                                                                      .Location)
                                                                              , "Resources", "Vagrantfile"))
                                                        .Build()
                       , new VagrantUpRequestBuilder().WithNameOrId("default")
                                                      .Build()
                       , new VagrantStatusRequestBuilder().WithNameOrId("default")
                                                          .Build()
                       , new VagrantSshConfigRequestBuilder().WithNameOrId("default")
                                                             .Build()
                       , new VagrantDestroyRequestBuilder().WithNameOrId("default")
                                                           .WithForce(true)
                                                           .Build()
                     };
    }

    [Test] [TestCaseSource(nameof(WorkflowData))]
    public async Task FullWorkflow(
        VagrantInitRequest      initRequest
      , VagrantUpRequest        upRequest
      , VagrantStatusRequest    statusRequest
      , VagrantSshConfigRequest sshConfigRequest
      , VagrantDestroyRequest   destroyRequest
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(services, async (
                                           serviceScope
                                         , token
                                       ) =>
                                       {
                                           await RunInternalAsync(serviceScope, initRequest, upRequest, statusRequest
                                                                , sshConfigRequest, destroyRequest, token);
                                       });
    }

    private async Task RunInternalAsync(
        AsyncServiceScope       scope
      , VagrantInitRequest      initRequest
      , VagrantUpRequest        upRequest
      , VagrantStatusRequest    statusRequest
      , VagrantSshConfigRequest sshConfigRequest
      , VagrantDestroyRequest   destroyRequest
      , CancellationToken       cancellationToken = default
    )
    {
        var tempFile = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        var context = new VagrantCommandExecutionContext
                      {
                          WorkingDirectory = tempFile
                      };

        Directory.CreateDirectory(tempFile);

        var initCommand  = scope.ServiceProvider.GetRequiredService<IVagrantInitCommand>();
        var initResponse = await initCommand.StartAsync(initRequest, context, new VagrantCommandExecutionListeners());
        initResponse.Should()
                    .NotBeNull();
        initResponse.ExitCode.Should()
                    .Be(0);

        var upCommand  = scope.ServiceProvider.GetRequiredService<IVagrantUpCommand>();
        var upResponse = await upCommand.StartAsync(upRequest, context, new VagrantCommandExecutionListeners());
        upResponse.ExitCode.Should()
                  .Be(0);

        var statusCommand = scope.ServiceProvider.GetRequiredService<IVagrantStatusCommand>();
        var statusResponse
            = await statusCommand.StartAsync(statusRequest, context, new VagrantCommandExecutionListeners());
        statusResponse.ExitCode.Should()
                      .Be(0);

        var sshConfigCommand = scope.ServiceProvider.GetRequiredService<IVagrantSshConfigCommand>();
        var sshConfigResponse
            = await sshConfigCommand.StartAsync(sshConfigRequest, context, new VagrantCommandExecutionListeners());
        sshConfigResponse.ExitCode.Should()
                         .Be(0);

        var destroyCommand = scope.ServiceProvider.GetRequiredService<IVagrantDestroyCommand>();
        var destroyResponse
            = await destroyCommand.StartAsync(destroyRequest, context, new VagrantCommandExecutionListeners());
        destroyResponse.ExitCode.Should()
                       .Be(0);
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.Configure(services);
        return Task.CompletedTask;
    }
}
