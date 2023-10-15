#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

using Frenchex.Dev.DotnetCore.Process.Lib.Domain;
using Frenchex.Dev.DotnetCore.Process.Lib.Domain.Abstractions;
using Frenchex.Dev.DotnetCore.Testing.Lib;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

#endregion

namespace Frenchex.Dev.DotnetCore.Process.Lib.Tests;

public class ProcessTests : AbstractFullWorkflowTester
{
    protected static IEnumerable<object[]> Data()
    {
        yield return new object[]
                     {
                         new Payload
                         {
                             Binary          = "dotnet"
                           , Arguments       = "--help"
                           , ExpectException = false
                         }
                     };

        yield return new object[]
                     {
                         new Payload
                         {
                             Binary          = "foo"
                           , Arguments       = "--help"
                           , ExpectException = true
                         }
                     };
    }


    [Test] [TestCaseSource(nameof(Data))] public async Task Test(
        Payload payload
    )
    {
        var services = await BuildServiceProviderAsync();

        await RunScopedAsync(
                             services
                           , async (
                                 scope
                               , token
                             ) =>
                             {
                                 await RunInternalAsync(scope, payload, token);
                             });
    }

    private async Task RunInternalAsync(
        AsyncServiceScope scope
      , Payload           payload
      , CancellationToken token
    )
    {
        var processStarterFactory = scope.ServiceProvider.GetRequiredService<IProcessStarterFactory>();

        var processStarter = processStarterFactory.Factory();

        var context = new ProcessExecutionContext(
                                                  Path.GetTempPath()
                                                , payload.Binary
                                                , payload.Arguments
                                                , new Dictionary<string, string>()
                                                , true
                                                , false);

        var stdOut = new List<string>();
        var stdErr = new List<string>();

        AddStOutAndStdErrListeners(processStarter, stdOut, stdErr);

        var processExecution = await processStarter.StartAsync(context, token);

        processExecution.HasStarted.ShouldBe(!payload.ExpectException);

        if (!payload.ExpectException)
        {
            await processExecution.WaitForExitAsync(token);


            stdOut.ShouldNotBeEmpty();
            stdErr.ShouldBeEmpty();
        }
        else
        {
            processExecution.HasStartingException.ShouldBeTrue();
            processExecution.StartingException.ShouldBeAssignableTo<Exception>();
        }
    }

    private static void AddStOutAndStdErrListeners(
        IProcessStarter processStarter
      , List<string>    stdOut
      , List<string>    stdErr
    )
    {
        processStarter.AddProcessPreparer(
                                          context =>
                                          {
                                              context.AddStdErrListener(
                                                                        line =>
                                                                        {
                                                                            stdErr.Add(line);
                                                                            return Task.CompletedTask;
                                                                        });

                                              context.AddStdOutListener(
                                                                        line =>
                                                                        {
                                                                            stdOut.Add(line);
                                                                            return Task.CompletedTask;
                                                                        });
                                              return Task.CompletedTask;
                                          });
    }

    protected override Task ConfigureServicesAsync(
        IServiceCollection services
      , CancellationToken  cancellationToken = default
    )
    {
        ServicesConfigurator.Configure(services);
        return Task.CompletedTask;
    }

    public class Payload
    {
        public required string Binary          { get; set; }
        public required string Arguments       { get; set; }
        public required bool   ExpectException { get; set; }
    }
}
