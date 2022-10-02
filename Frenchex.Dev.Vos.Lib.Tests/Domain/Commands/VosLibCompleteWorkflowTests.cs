using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;
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
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Networking;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

[TestClass]
public class VosLibCompleteWorkflowTests : AbstractUnitTest
{
    private const string BoxTest = "generic/alpine316";
    private const string BoxVersionTest = "4.1.10";

    private UnitTest? _unitTest;

    public static IEnumerable<object[]> DataSource(int maxX, int maxY)
    {
        for (var i = 0; i < maxX; i++)
        {
            List<Builder> list = new List<Builder>();

            for (var j = 0; j < maxY; j++)
            {
                var builder = new Builder();

                builder.BuildInitCommandRequestBuilder = BuildInitCommandRequest;
                builder.BuildDefineMachineTypeAddCommandRequestsListBuilder =
                    BuildDefineMachineTypeAddCommandRequestsList;

                builder.BuildDefineMachineAddCommandRequestsListBuilder = BuildDefineMachineAddCommandRequestsList;
                builder.BuildNameCommandRequestsListBuilder = BuildNameCommandRequestsList;
                builder.BuildStatusBeforeUpCommandRequestsListBuilder = BuildStatusBeforeUpCommandRequestsList;
                builder.BuildUpCommandRequestsListBuilder = BuildUpCommandRequestsList;
                builder.BuildStatusAfterUpCommandRequestsListBuilder = BuildStatusAfterUpCommandRequestsList;
                builder.BuildSshConfigCommandRequestsListBuilder = BuildSshConfigCommandRequestsList;
                builder.BuildSshCommandRequestsListBuilder = BuildSshCommandRequestsList;
                builder.BuildHaltCommandRequestsListBuilder = BuildHaltCommandRequestsList;
                builder.BuildDestroyCommandRequestsListBuilder = BuildDestroyCommandRequestsList;

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
        var timeout = TimeSpan.FromMinutes(10);
        var globalTimeoutTask = Task.Delay((int) timeout.TotalMilliseconds);

        Func<Builder, Task> taskBuilder = (Builder builder) => VosWorkflowUnitTestInternalInternal(
            builder.BuildInitCommandRequestBuilder!,
            builder.BuildDefineMachineTypeAddCommandRequestsListBuilder!,
            builder.BuildDefineMachineAddCommandRequestsListBuilder!,
            builder.BuildNameCommandRequestsListBuilder!,
            builder.BuildStatusBeforeUpCommandRequestsListBuilder!,
            builder.BuildUpCommandRequestsListBuilder!,
            builder.BuildStatusAfterUpCommandRequestsListBuilder!,
            builder.BuildSshConfigCommandRequestsListBuilder!,
            builder.BuildSshCommandRequestsListBuilder!,
            builder.BuildHaltCommandRequestsListBuilder!,
            builder.BuildDestroyCommandRequestsListBuilder!
        );

        List<Task> allTasks = builders.Select(x => taskBuilder(x)).ToList();
        var tasks = Task.WhenAll(allTasks);

        await Task.WhenAny(tasks, globalTimeoutTask);

        if (tasks.IsFaulted)
        {
            throw new Exception(tasks?.Exception?.Message);
        }
    }

    private async Task VosWorkflowUnitTestInternalInternal(
        Func<string, IServiceProvider, IInitCommandRequest> initRequestBuilder,
        Func<string, IServiceProvider, IList<IDefineMachineTypeAddCommandRequest>>
            defineMachineTypeAddCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<IDefineMachineAddCommandRequest>>
            defineMachineAddCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<NameCommandRequestPayload>> nameCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusBeforeUpCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<IUpCommandRequest>> upRequestsListBuilder,
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusAfterUpCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<ISshConfigCommandRequest>> sshConfigCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<ISshCommandRequest>> sshCommandRequestsListBuilder,
        Func<string, IServiceProvider, IList<IHaltCommandRequest>> haltRequestsListBuilder,
        Func<string, IServiceProvider, IList<IDestroyCommandRequest>> destroyRequestsListBuilder
    )
    {
        var vsDebuggingContext = new UnitTest.VsCodeDebugging {TellMe = true, Keep = true, DevDebugging = true};
        var workingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        var unitTest = _unitTest = VosUnitTestBase.CreateUnitTest<ExecutionContext>();
        unitTest.BuildIfNecessary();

        await RunInitCommandAsyncUnitTest(
            initRequestBuilder,
            unitTest,
            workingDirectory,
            vsDebuggingContext,
            TimeSpan.FromSeconds(10)
        );

        await RunDefineMachineTypeAddCommandsAsyncUnitTest(
            defineMachineTypeAddCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromSeconds(3)
        );

        await RunDefineMachineAddCommandsAsyncUnitTest(
            defineMachineAddCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromSeconds(3)
        );

        await RunNameCommandsAsyncUnitTest(
            nameCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromSeconds(2)
        );

        await RunStatusCommandsResponseBeforeUpAsyncUnitTest(
            statusBeforeUpCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromSeconds(30)
        );

        await RunUpAndStatusAfterUpRequestsCommandsAsyncUnitTest(
            upRequestsListBuilder,
            statusAfterUpCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromMinutes(4)
        );

        await RunSshConfigCommandRequestsAsyncUnitTest(
            sshConfigCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromMinutes(4)
        );

        await RunSshCommandsAsyncUnitTest(
            sshCommandRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromMinutes(4)
        );

        await RunHaltCommandsAsyncUnitTest(
            haltRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromMinutes(4)
        );

        await RunDestroyCommandsAsyncUnitTest(
            destroyRequestsListBuilder,
            unitTest,
            vsDebuggingContext,
            TimeSpan.FromMinutes(4)
        );

        vsDebuggingContext.Stop();
    }

    private async static Task RunDestroyCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDestroyCommandRequest>> destroyRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunHaltCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IHaltCommandRequest>> haltRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunSshCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<ISshCommandRequest>> sshCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunSshConfigCommandRequestsAsyncUnitTest(
        Func<string, IServiceProvider, IList<ISshConfigCommandRequest>> sshConfigCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeSpan
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunUpAndStatusAfterUpRequestsCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IUpCommandRequest>> upRequestsListBuilder,
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusAfterUpCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan totalTimeSpan
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunStatusCommandsResponseBeforeUpAsyncUnitTest(
        Func<string, IServiceProvider, IList<IStatusCommandRequest>> statusBeforeUpCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunNameCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<NameCommandRequestPayload>> nameCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunDefineMachineAddCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDefineMachineAddCommandRequest>>
            defineMachineAddCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext
        );
    }

    private async static Task RunDefineMachineTypeAddCommandsAsyncUnitTest(
        Func<string, IServiceProvider, IList<IDefineMachineTypeAddCommandRequest>>
            defineMachineTypeAddCommandRequestsListBuilder,
        UnitTest unitTest,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private async static Task RunInitCommandAsyncUnitTest(
        Func<string, IServiceProvider, IInitCommandRequest> initRequestBuilder,
        UnitTest unitTest,
        string workingDirectory,
        UnitTest.VsCodeDebugging vsDebuggingContext,
        TimeSpan timeBox
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
            unitTest.ServiceProvider ?? throw new ArgumentNullException(nameof(unitTest.ServiceProvider)),
            vsDebuggingContext);
    }

    private static List<IStatusCommandRequest> BuildStatusAfterUpCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        var factory = serviceProvider.GetRequiredService<IStatusCommandRequestBuilderFactory>();

        return new List<IStatusCommandRequest> {
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"foo-0", "foo-1"})
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-1"})
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-0"})
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-[0-*]", "foo-[0-*]"})
                .Build()
        };
    }

    private static List<IStatusCommandRequest> BuildStatusBeforeUpCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        return new List<IStatusCommandRequest> {
            serviceProvider.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IStatusCommandRequestBuilder>()
                .Build()
        };
    }

    private static List<IDestroyCommandRequest> BuildDestroyCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        return new List<IDestroyCommandRequest> {
            serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .UsingName("foo-0")
                .Build(),
            serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .UsingName("foo-1")
                .Build(),
            serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .Build()
        };
    }

    private static List<IHaltCommandRequest> BuildHaltCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        var factory = serviceProvider.GetRequiredService<IHaltCommandRequestBuilderFactory>();

        return new List<IHaltCommandRequest> {
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IHaltCommandRequestBuilder>()
                .UsingNames(new[] {"foo-0", "foo-1"})
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IHaltCommandRequestBuilder>()
                .UsingNames(new[] {"bar-0"})
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IHaltCommandRequestBuilder>()
                .Build()
        };
    }

    private static List<ISshCommandRequest> BuildSshCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        return new List<ISshCommandRequest> {
            serviceProvider.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<ISshCommandRequestBuilder>()
                .UsingNames(new[] {"foo-1"})
                .UsingCommands(new[] {"echo foo"})
                .Build(),
            serviceProvider.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<ISshCommandRequestBuilder>()
                .UsingNames(new[] {"bar-0"})
                .UsingCommands(new[] {"echo bar"})
                .Build()
        };
    }

    private static List<ISshConfigCommandRequest> BuildSshConfigCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        var factory = serviceProvider.GetRequiredService<ISshConfigCommandRequestBuilderFactory>();

        return new List<ISshConfigCommandRequest> {
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingNamesOrIds(new[] {
                    "foo-0"
                })
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingNamesOrIds(new[] {
                    "bar-1"
                })
                .Build()
        };
    }

    private static List<IUpCommandRequest> BuildUpCommandRequestsList(
        string? workingDirectory,
        IServiceProvider serviceProvider
    )
    {
        var factory = serviceProvider.GetRequiredService<IUpCommandRequestBuilderFactory>();

        return new List<IUpCommandRequest> {
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IUpCommandRequestBuilder>()
                .UsingNames(new[] {"foo-0", "foo-1"})
                .WithParallel(true)
                .WithProvision(false)
                .Build(),
            factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("1m")
                .Parent<IUpCommandRequestBuilder>()
                .UsingNames(new[] {"foo-2"})
                .WithParallel(true)
                .WithProvision(false)
                .Build()
        };
    }

    private static List<IDefineMachineAddCommandRequest> BuildDefineMachineAddCommandRequestsList(
        string? tempDir,
        IServiceProvider serviceProvider
    )
    {
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge = serviceProvider
            .GetRequiredService<IDefaultGatewayGetterAction>()
            .GetDefaultGateway();

        List<IDefineMachineAddCommandRequest> list = new List<IDefineMachineAddCommandRequest>();

        List<DefineMachineAddCommandRequestPayload> payloads = new List<DefineMachineAddCommandRequestPayload> {
            new("foo", "10.100.2.#INSTANCE#", true),
            new("bar", "10.100.3.#INSTANCE#", false)
        };

        foreach (var payload in payloads)
        {
            var def = BuildDefineMachineAddCommandRequest(
                tempDir,
                "20s",
                true,
                "",
                new Dictionary<string, FileCopyDefinition>(),
                false,
                OsTypeEnum.Debian_64,
                "10.9.0",
                false,
                ProviderEnum.Virtualbox,
                new Dictionary<string, ProvisioningDefinition> {
                    {
                        "docker.install", new ProvisioningDefinition {
                            Env = new Dictionary<string, string> {
                                {"DOCKER_VERSION", "20.9"}
                            }
                        }
                    }
                },
                new Dictionary<string, SharedFolderDefinition>(),
                16,
                128,
                2,
                "foo",
                payload.Name,
                4,
                2,
                payload.Ipv4Pattern,
                true,
                true,
                defaultSystemNetworkBridge,
                serviceProvider.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>(),
                serviceProvider.GetRequiredService<MachineDefinitionBuilderFactory>());

            list.Add(def);
        }

        return list;
    }

    private static IDefineMachineAddCommandRequest BuildDefineMachineAddCommandRequest(
        string? workingDirectory,
        string timeoutStr,
        bool enable3d,
        string biosLogoImage,
        Dictionary<string, FileCopyDefinition> withFiles,
        bool withGui,
        OsTypeEnum withOsTypeEnum,
        string withOsVersion,
        bool withPageFusion,
        ProviderEnum withProvider,
        Dictionary<string, ProvisioningDefinition> provisioningDefinitions,
        Dictionary<string, SharedFolderDefinition> sharedFolderDefinitions,
        int videoRamInMb,
        int ramInMb,
        int vCpus,
        string machineTypeDefinitionName,
        string name,
        int instances,
        int ipv4Start,
        string ipv4Pattern,
        bool isPrimary,
        bool enabled,
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge,
        IDefineMachineAddCommandRequestBuilderFactory defineMachineAddCommandRequestBuilderFactory,
        MachineDefinitionBuilderFactory machineDefinitionBuilderFactory
    )
    {
        return defineMachineAddCommandRequestBuilderFactory
            .Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeout(timeoutStr)
            .Parent<IDefineMachineAddCommandRequestBuilder>()
            .UsingDefinition(machineDefinitionBuilderFactory
                .Factory()
                .BaseBuilder
                .With3DEnabled(enable3d)
                .WithBiosLogoImage(biosLogoImage)
                .WithFiles(withFiles)
                .WithGui(withGui)
                .WithOsType(withOsTypeEnum)
                .WithOsVersion(withOsVersion)
                .WithPageFusion(withPageFusion)
                .WithProvider(withProvider)
                .WithProvisioning(provisioningDefinitions)
                .WithSharedFolders(sharedFolderDefinitions)
                .WithVideoRamInMb(videoRamInMb)
                .WithRamInMb(ramInMb)
                .WithVirtualCpus(vCpus)
                .Parent<MachineDefinitionBuilder>()
                .WithMachineType(machineTypeDefinitionName)
                .WithName(name)
                .WithInstances(instances)
                .WithIPv4Start(ipv4Start)
                .WithIPv4Pattern(ipv4Pattern)
                .IsPrimary(isPrimary)
                .Enabled(enabled)
                .WithNetworkBridge(defaultSystemNetworkBridge.First().Item1.Description)
                .Build()
            )
            .Build();
    }

    private static IDefineMachineTypeAddCommandRequest
        BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
            string workingDirectory,
            string typeName,
            string boxName,
            string boxVersion,
            IServiceProvider serviceProvider
        )
    {
        return serviceProvider.GetRequiredService<IDefineMachineTypeAddCommandRequestBuilderFactory>()
            .Factory()
            .BaseBuilder.UsingWorkingDirectory(workingDirectory)
            .UsingTimeout("2m")
            .Parent<IDefineMachineTypeAddCommandRequestBuilder>()
            .UsingDefinition(serviceProvider.GetRequiredService<IMachineTypeDefinitionBuilderFactory>()
                .Factory()
                .BaseBuilder
                .With3DEnabled(true)
                .WithBiosLogoImage("")
                .WithBox(boxName)
                .WithBoxVersion(boxVersion)
                .WithFiles(new Dictionary<string, FileCopyDefinition>())
                .WithGui(false)
                .WithOsType(OsTypeEnum.Debian_64)
                .WithOsVersion("10.5.0")
                .WithPageFusion(false)
                .WithRamInMb(256)
                .WithVideoRamInMb(16)
                .WithVirtualCpus(4)
                .WithFiles(new Dictionary<string, FileCopyDefinition>())
                .WithProvisioning(new Dictionary<string, ProvisioningDefinition>())
                .WithSharedFolders(new Dictionary<string, SharedFolderDefinition>())
                .Enabled(true)
                .Parent<IMachineTypeDefinitionBuilder>()
                .WithName(typeName)
                .Build())
            .Build();
    }

    private static List<IDefineMachineTypeAddCommandRequest> BuildDefineMachineTypeAddCommandRequestsList(
        string tempDir,
        IServiceProvider serviceProvider
    )
    {
        List<IDefineMachineTypeAddCommandRequest> list = new() {
            BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
                tempDir,
                "foo",
                BoxTest,
                BoxVersionTest,
                serviceProvider),
            BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
                tempDir,
                "bar",
                BoxTest,
                BoxVersionTest,
                serviceProvider)
        };

        return list;
    }

    private static IInitCommandRequest BuildInitCommandRequest(string tempDir, IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingWorkingDirectory(tempDir)
            .UsingTimeout("20s")
            .Parent<IInitCommandRequestBuilder>()
            .WithGivenLeadingZeroes(2)
            .Build();
    }


    private static List<NameCommandRequestPayload> BuildNameCommandRequestsList(
        string? tempDir,
        IServiceProvider serviceProvider
    )
    {
        var factory = serviceProvider.GetRequiredService<INameCommandRequestBuilderFactory>();
        List<NameCommandRequestPayload> list = new List<NameCommandRequestPayload>();

        var nameCommandRequest = factory.Factory()
            .BaseBuilder
            .UsingWorkingDirectory(tempDir)
            .UsingTimeout("20s")
            .Parent<INameCommandRequestBuilder>()
            .WithNames(new[] {"foo-0", "bar-[2-*]"})
            .Build();

        var payload = new NameCommandRequestPayload(nameCommandRequest) {
            ExpectedNames = new List<string> {"foo-00", "bar-02"}
        };

        list.Add(payload);

        return list;
    }

    private class DefineMachineAddCommandRequestPayload
    {
        public DefineMachineAddCommandRequestPayload(string name, string ipv4Pattern, bool isPrimary)
        {
            Name = name;
            Ipv4Pattern = ipv4Pattern;
            IsPrimary = isPrimary;
        }

        public string Name { get; }
        public string Ipv4Pattern { get; }
        public bool IsPrimary { get; }
    }
}