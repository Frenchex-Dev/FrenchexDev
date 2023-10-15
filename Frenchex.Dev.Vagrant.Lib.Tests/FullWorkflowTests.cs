#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using System.Reflection;
using FluentAssertions;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions;
using Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests;

public class FullWorkflowTests : AbstractFullWorkflowTester
{
    protected static IEnumerable<object[]> WorkflowData()
    {
        yield return new object[]
                     {
                         new List<IVagrantCommandRequest>
                         {
                             new VagrantInitRequestBuilder()
                                 .WithName("generic/alpine318")
                                 .WithTemplate(
                                               Path.Join(
                                                         Path.GetDirectoryName(
                                                                               Assembly.GetCallingAssembly()
                                                                                       .Location)
                                                       , "Resources"
                                                       , "Vagrantfile"))
                                 .Build()
                           , new VagrantUpRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                           , new VagrantStatusRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                           , new VagrantSshConfigRequestBuilder()
                             .WithNameOrId("default")
                             .Build()
                           , new VagrantDestroyRequestBuilder()
                             .WithNameOrId("default")
                             .WithForce(true)
                             .Build()
                         }
                     };
    }

    [Test] [TestCaseSource(nameof(WorkflowData))]
    public async Task FullWorkflow(
        List<IVagrantCommandRequest> requests
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(
                             services
                           , async (
                                 serviceScope
                               , token
                             ) =>
                             {
                                 await RunInternalAsync(serviceScope, requests, token);
                             });
    }

    private static async Task RunInternalAsync(
        AsyncServiceScope            scope
      , List<IVagrantCommandRequest> requests
      , CancellationToken            _ = default
    )
    {
        var tempFile = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        var context = new VagrantCommandExecutionContext
                      {
                          WorkingDirectory = tempFile,
                          SaveStdErrStream = true,
                          SaveStdOutStream = true
                      };

        Directory.CreateDirectory(tempFile);

        var commandsFacade = scope.ServiceProvider.GetRequiredService<IVagrantCommandsFacade>();

        foreach (var request in requests)
        {
            var response = await commandsFacade.StartAsync(request, context, new VagrantCommandExecutionListeners(), _);

            response
                .Should()
                .NotBeNull();

            response
                .ExitCode
                .Should()
                .Be(0);
        }
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
