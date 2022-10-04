using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Response;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Command;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

[TestClass]
public class VosLibCompleteWorkflowTests : AbstractUnitTest
{
    private UnitTest? _unitTest;

    public static IEnumerable<object[]> DataSource(int maxX, int maxY)
    {
        for (var i = 0; i < maxX; i++)
        {
            List<Builder> list = new();

            for (var j = 0; j < maxY; j++)
            {
                var builder = new Builder();
                list.Add(builder);
            }

            yield return new object[] {list.ToArray()};
        }
    }

    public static IEnumerable<object[]> DataSourceMaximal()
    {
        var maxX = 2;
        var maxY = 2;

        return DataSource(maxX, maxY);
    }

    public static IEnumerable<object[]> DataSourceMinimal()
    {
        var maxX = 1;
        var maxY = 1;

        return DataSource(maxX, maxY);
    }

    [TestCleanup]
    public async Task CleanUp()
    {
        await Task.Run(() => _unitTest?.DisposeAsync());
    }

    [TestMethod]
    [DynamicData(nameof(DataSourceMaximal), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    [TestCategory(TestCategories.TestingLevelMaximal)]
    public async Task VosWorkflowUnitTestMaximal(Builder[] builders)
    {
        await VosWorkflowUnitTestInternal(builders);
    }

    [TestMethod]
    [DynamicData(nameof(DataSourceMinimal), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    [TestCategory(TestCategories.TestingLevelMinimal)]
    public async Task VosWorkflowUnitTestMinimal(Builder[] builders)
    {
        await VosWorkflowUnitTestInternal(builders);
    }


    private async Task VosWorkflowUnitTestInternal(Builder[] builders)
    {
        Func<Builder, Task> taskBuilder = (Builder builder) => VosWorkflowUnitTestInternalInternal(builder);

        List<Task> allTasks = builders.Select(x => taskBuilder(x)).ToList();

        var tasks = Task.WhenAll(allTasks);

        await tasks;

        if (tasks.IsFaulted)
        {
            throw new Exception(tasks.Exception?.Message);
        }
    }

    private async Task VosWorkflowUnitTestInternalInternal(Builder builder)
    {
        var vsDebuggingContext = new UnitTest.VsCodeDebugging {TellMe = true, Keep = true, DevDebugging = true};
        var workingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        var unitTest = _unitTest = VosUnitTestBase.CreateUnitTest<ExecutionContext>();
        unitTest.BuildIfNecessary();

        await RunInitCommandAsyncUnitTest(
            builder.BuildInitCommandRequestBuilder!,
            unitTest,
            workingDirectory,
            vsDebuggingContext,
            "10s"
        );

        await RunDefineMachineTypeAddCommandsAsyncUnitTest(
            builder.BuildDefineMachineTypeAddCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "3s"
        );

        await RunDefineMachineAddCommandsAsyncUnitTest(
            builder.BuildDefineMachineAddCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "3s"
        );

        await RunNameCommandsAsyncUnitTest(
            builder.BuildNameCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "2s"
        );

        await RunStatusCommandsResponseBeforeUpAsyncUnitTest(
            builder.BuildStatusBeforeUpCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "30s"
        );

        await RunUpAndStatusAfterUpRequestsCommandsAsyncUnitTest(
            builder.BuildUpCommandRequestsListBuilder!,
            builder.BuildStatusAfterUpCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "4m"
        );

        await RunSshConfigCommandRequestsAsyncUnitTest(
            builder.BuildSshConfigCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "4m"
        );

        await RunSshCommandsAsyncUnitTest(
            builder.BuildSshCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "4m"
        );

        await RunHaltCommandsAsyncUnitTest(
            builder.BuildHaltCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "4m"
        );

        await RunDestroyCommandsAsyncUnitTest(
            builder.BuildDestroyCommandRequestsListBuilder!,
            unitTest,
            vsDebuggingContext,
            "4m"
        );

        vsDebuggingContext.Stop();
    }

    private async static Task RunDestroyCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDestroyCommandRequest>> destroyRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAndCleanupAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                IList<IDestroyCommandRequest> list = destroyRequestsListBuilder(context.WorkingDirectory!, provider);
                var command = provider.GetRequiredService<IDestroyCommand>();
                context.DestroyCommandsResponses = new List<(IDestroyCommandRequest, IDestroyCommandResponse)>();

                foreach (var item in list)
                {
                    var response = await command.ExecuteAsync(item);
                    context.DestroyCommandsResponses.Add((item, response));
                }
            },
            async (provider, _, context) =>
            {
                var statusCommand = provider.GetRequiredService<IStatusCommand>();
                var statusCommandRequest = provider.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(context.WorkingDirectory)
                    .UsingTimeout("10s")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(context.WillBeUp!.ToArray())
                    .Build();

                var statusCommandResponse = await statusCommand.ExecuteAsync(statusCommandRequest);

                foreach (KeyValuePair<string, (string, VagrantMachineStatusEnum)> name in
                         statusCommandResponse.Statuses)
                {
                    Assert.AreEqual(VagrantMachineStatusEnum.NotCreated.ToString(), name.Value.ToString());
                }
            },
            async (_, _, context) =>
            {
                Directory.Delete(context.WorkingDirectory!, true);
                await Task.Delay((int) TimeSpan.FromSeconds(2).TotalMilliseconds);
                Assert.IsFalse(Directory.Exists(context.WorkingDirectory));
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunHaltCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IHaltCommandRequest>> haltRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                IList<IHaltCommandRequest> list = haltRequestsListBuilder(context.WorkingDirectory!, provider);
                var command = provider.GetRequiredService<IHaltCommand>();

                context.HaltCommandsResponses = new List<(IHaltCommandRequest, IHaltCommandResponse)>();

                foreach (var item in list)
                {
                    var response = await command.ExecuteAsync(item);
                    context.HaltCommandsResponses.Add((item, response));
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.HaltCommandsResponses!.Any());
                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunSshCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<ISshCommandRequest>> sshCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                IList<ISshCommandRequest> list = sshCommandRequestsListBuilder(context.WorkingDirectory!, provider);
                var command = provider.GetRequiredService<ISshCommand>();
                context.SshCommandsResponses = new List<(ISshCommandRequest, ISshCommandResponse)>();

                foreach (var item in list)
                {
                    var response = await command.ExecuteAsync(item);
                    context.SshCommandsResponses.Add((item, response));
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.SshCommandsResponses!.Any());
                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunSshConfigCommandRequestsAsyncUnitTest(
        Func<string, IServiceProvider, IList<ISshConfigCommandRequest>> sshConfigCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeSpan
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeSpan,
            async (provider, _, context, _) =>
            {
                IList<ISshConfigCommandRequest> list =
                    sshConfigCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                var command = provider.GetRequiredService<ISshConfigCommand>();
                context.SshConfigCommandsResponses = new List<(ISshConfigCommandRequest, ISshConfigCommandResponse)>();

                foreach (var item in list)
                {
                    var response = await command.ExecuteAsync(item);
                    context.SshConfigCommandsResponses.Add((item, response));
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.SshConfigCommandsResponses!.Any());

                foreach (var runningContext in context.SshConfigCommandsResponses!)
                {
                    var request = runningContext.Item1;
                    var response = runningContext.Item2;

                    Assert.IsNotNull(request);
                    Assert.IsNotNull(response);
                }

                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunUpAndStatusAfterUpRequestsCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IUpCommandRequest>> upRequestsListBuilder,
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusAfterUpCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string totalTimeSpan
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            totalTimeSpan,
            async (provider, _, context, _) =>
            {
                context.WillBeUp = new List<string>();
                IList<IUpCommandRequest> list = upRequestsListBuilder(context.WorkingDirectory!, provider);
                context.UpCommandsResponses = new List<(IUpCommandRequest, IUpCommandResponse)>();
                var command = provider.GetRequiredService<IUpCommand>();

                foreach (var item in list)
                {
                    var upResponse = await command.ExecuteAsync(item);
                    context.UpCommandsResponses.Add((item, upResponse));
                    Assert.IsNotNull(upResponse.Response);
                    Assert.IsNotNull(upResponse.Response.ProcessExecutionResult.WaitForCompleteExit);
                    var consoleOutputStream = new StreamWriter(Console.OpenStandardOutput());
                    consoleOutputStream.AutoFlush = true;
                    Console.SetOut(consoleOutputStream);
                    await upResponse.Response.ProcessExecutionResult.WaitForCompleteExit;

                    Assert.IsTrue(
                        new List<int> {0, 1}.Contains((int) upResponse.Response.ProcessExecutionResult.ExitCode!),
                        "up exit code is zero");

                    var nameCommand = provider.GetRequiredService<INameCommand>();
                    var nameCommandRequestBuilderFactory =
                        provider.GetRequiredService<INameCommandRequestBuilderFactory>();

                    var realNames = await nameCommand.ExecuteAsync(
                        nameCommandRequestBuilderFactory.Factory()
                            .BaseBuilder
                            .UsingWorkingDirectory(context.WorkingDirectory)
                            .Parent<INameCommandRequestBuilder>()
                            .WithNames(item.Names)
                            .Build());

                    context.WillBeUp.AddRange(realNames.Names);
                }
            },
            async (provider, _, context) =>
            {
                IList<IStatusCommandRequest> listStatusRequestAfterUp =
                    statusAfterUpCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                var statusCommand = provider.GetRequiredService<IStatusCommand>();

                foreach (var subItem in listStatusRequestAfterUp)
                {
                    var statusResponse = await statusCommand.ExecuteAsync(subItem);
                    Assert.IsNotNull(statusResponse);
                    Assert.IsTrue(statusResponse.Statuses.Any());

                    foreach (var (key, value) in statusResponse.Statuses)
                    {
                        Assert.IsTrue(value.ToString().Contains(
                            context.WillBeUp!.Contains(key)
                                ? VagrantMachineStatusEnum.Running.ToString()
                                : VagrantMachineStatusEnum.NotCreated.ToString()));
                    }
                }
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext
        );
    }

    private async static Task RunStatusCommandsResponseBeforeUpAsyncUnitTest(
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusBeforeUpCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                var statusCommand = provider.GetRequiredService<IStatusCommand>();
                IList<IStatusCommandRequest> list =
                    statusBeforeUpCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                context.StatusCommandsResponseBeforeUp = new List<IStatusCommandResponse>();
                foreach (var item in list)
                {
                    var statusResponse = await statusCommand.ExecuteAsync(item);
                    context.StatusCommandsResponseBeforeUp.Add(statusResponse);
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.StatusCommandsResponseBeforeUp!.Any());
                foreach (var response in context.StatusCommandsResponseBeforeUp!)
                {
                    Assert.IsNotNull(response, "got status response");
                    Assert.IsTrue(response.Statuses.Any(), "got machines in status response");
                    Assert.IsTrue(response
                        .Statuses
                        .All(x => x.Value
                            .ToString()
                            .Contains(VagrantMachineStatusEnum.NotCreated.ToString())));
                }

                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunNameCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<NameCommandRequestPayload>> nameCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                var nameCommand = provider.GetRequiredService<INameCommand>();
                IList<NameCommandRequestPayload> list =
                    nameCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                context.NameCommandsResponses = new List<(NameCommandRequestPayload, INameCommandResponse)>();

                foreach (var item in list)
                {
                    var response = await nameCommand.ExecuteAsync(item.Request);
                    context.NameCommandsResponses.Add((item, response));
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.NameCommandsResponses!.Any());

                foreach (var item in context.NameCommandsResponses!)
                {
                    if (item.Item1.ExpectedNames.Any())
                    {
                        Assert.IsTrue(item.Item1.ExpectedNames.All(x => item.Item2.Names.Contains(x)));
                    }
                }

                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunDefineMachineAddCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDefineMachineAddCommandRequest>>
            defineMachineAddCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                var defineMachineAddCommand = provider.GetRequiredService<IDefineMachineAddCommand>();
                IList<IDefineMachineAddCommandRequest> list =
                    defineMachineAddCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                context.DefineMachineAddCommandsResponses = new List<IDefineMachineAddCommandResponse>();
                foreach (var item in list)
                {
                    var response = await defineMachineAddCommand.ExecuteAsync(item);
                    context.DefineMachineAddCommandsResponses.Add(response);
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.DefineMachineAddCommandsResponses!.Any());
                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext
        );
    }

    private async static Task RunDefineMachineTypeAddCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDefineMachineTypeAddCommandRequest>>
            defineMachineTypeAddCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, _) =>
            {
                var defineMachineTypeAddCommand = provider.GetRequiredService<IDefineMachineTypeAddCommand>();
                IList<IDefineMachineTypeAddCommandRequest> list =
                    defineMachineTypeAddCommandRequestsListBuilder(context.WorkingDirectory!, provider);

                context.DefineMachineTypeAddCommandsResponses = new List<IDefineMachineTypeAddCommandResponse>();
                foreach (var item in list)
                {
                    var response = await defineMachineTypeAddCommand.ExecuteAsync(item);
                    context.DefineMachineTypeAddCommandsResponses.Add(response);
                }
            },
            (_, _, context) =>
            {
                Assert.IsTrue(context.DefineMachineTypeAddCommandsResponses!.Any());

                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }

    private async static Task RunInitCommandAsyncUnitTest(
        Func<string, IServiceProvider, IInitCommandRequest> initRequestBuilder,
        UnitTest unitTest,
        string workingDirectory,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        string timeBox
    )
    {
        await unitTest.ExecuteTimeBoxedAndAssertAsync<ExecutionContext>(
            timeBox,
            async (provider, _, context, vsCode) =>
            {
                context.WorkingDirectory = workingDirectory;

                var initCommand = provider.GetRequiredService<IInitCommand>();
                var initRequest = initRequestBuilder(workingDirectory, provider);
                context.InitCommandResponse = await initCommand.ExecuteAsync(initRequest);

                vsCode.Invoke(context.WorkingDirectory);
            },
            (_, _, context) =>
            {
                Assert.IsInstanceOfType(context.InitCommandResponse, typeof(IInitCommandResponse));

                return Task.CompletedTask;
            },
            unitTest.GetScopedServiceProvider(),
            vsDebuggingContext);
    }
}