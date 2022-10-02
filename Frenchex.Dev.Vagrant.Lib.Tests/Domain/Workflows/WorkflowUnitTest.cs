using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

[TestClass]
public class VagrantLibCompleteWorkflowTests : AbstractUnitTest
{
    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[] {
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("1m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IInitCommandRequestBuilder>()
                .UsingBoxName("generic/alpine38")
                .UsingBoxVersion("4.1.10")
                .Build(),
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("10m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IUpCommandRequestBuilder>()
                .WithProvision(false)
                .Build(),
            (string workingDirectory, IServiceProvider sp) =>
            {
                var factory =
                    sp.GetRequiredService<IProvisionCommandRequestBuilderFactory>();

                var builder = factory.Factory();

                builder
                    .BaseBuilder
                    .UsingTimeout("1m")
                    .UsingWorkingDirectory(workingDirectory)
                    .Parent<IProvisionCommandRequestBuilder>()
                    .ProvisionWith(new[] {"docker.install"})
                    ;

                return builder.Build();
            },
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("1m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IStatusCommandRequestBuilder>()
                .Build(),
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("1m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingName("default")
                .Build(),
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("1m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<ISshCommandRequestBuilder>()
                .UsingCommand("echo foo")
                .UsingNameOrId("default")
                .Build(),
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("3m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IHaltCommandRequestBuilder>()
                .Build(),
            (string workingDirectory, IServiceProvider sp) => sp
                .GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeout("3m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .Build()
        };
    }

    [TestInitialize]
    public void TestInit()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    public async Task Test_Complete_Workflow(
        Func<string, IServiceProvider, IInitCommandRequest> initRequestBuilder,
        Func<string, IServiceProvider, IUpCommandRequest> upRequestBuilder,
        Func<string, IServiceProvider, IProvisionCommandRequest> provisionRequestBuilder,
        Func<string, IServiceProvider, IStatusCommandRequest> statusRequestBuilder,
        Func<string, IServiceProvider, ISshConfigCommandRequest> sshConfigCommandRequestBuilder,
        Func<string, IServiceProvider, ISshCommandRequest> sshCommandRequestBuilder,
        Func<string, IServiceProvider, IHaltCommandRequest> haltRequestBuilder,
        Func<string, IServiceProvider, IDestroyCommandRequest> destroyRequestBuilder
    )
    {
        // directory is created by Init command
        var workingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
        var sp = UnitTest!.ServiceProvider!;

        if (sp == null)
            throw new ArgumentNullException(nameof(sp));

        var initRequest = initRequestBuilder.Invoke(workingDirectory, sp);
        var upRequest = upRequestBuilder.Invoke(workingDirectory, sp);
        var provisionRequest = provisionRequestBuilder.Invoke(workingDirectory, sp);
        var statusRequest = statusRequestBuilder.Invoke(workingDirectory, sp);
        var sshConfigCommandRequest = sshConfigCommandRequestBuilder.Invoke(workingDirectory, sp);
        var sshCommandRequest = sshCommandRequestBuilder.Invoke(workingDirectory, sp);
        var haltRequest = haltRequestBuilder.Invoke(workingDirectory, sp);
        var destroyRequest = destroyRequestBuilder.Invoke(workingDirectory, sp);

        await UnitTest!.ExecuteAndAssertAndCleanupAsync<ExecutionContext>(async (provider, _, _, _) =>
            {
                await TestInner(
                    "init",
                    provider.GetRequiredService<IInitCommand>().StartProcess(initRequest),
                    new List<int> {0, 1},
                    true);

                // vsCode.Invoke(initRequest.Base.WorkingDirectory!);

                await TestInner(
                    "status",
                    provider.GetRequiredService<IStatusCommand>().StartProcess(statusRequest),
                    new List<int> {0},
                    true
                );

                await TestInner(
                    "up",
                    provider.GetRequiredService<IUpCommand>().StartProcess(upRequest),
                    new List<int> {0, 1},
                    true
                );

                await TestInner(
                    "provision",
                    provider.GetRequiredService<IProvisionCommand>().StartProcess(provisionRequest),
                    new List<int> {0, 1},
                    true
                );

                await TestInner("ssh-config",
                    provider.GetRequiredService<ISshConfigCommand>().StartProcess(sshConfigCommandRequest),
                    new List<int> {0},
                    true
                );

                await TestInner(
                    "ssh",
                    provider.GetRequiredService<ISshCommand>().StartProcess(sshCommandRequest),
                    new List<int> {0},
                    true
                );

                await TestInner(
                    "halt",
                    provider.GetRequiredService<IHaltCommand>().StartProcess(haltRequest),
                    new List<int> {0},
                    true
                );

                await TestInner(
                    "destroy",
                    provider.GetRequiredService<IDestroyCommand>().StartProcess(destroyRequest),
                    new List<int> {0},
                    true
                );
            },
            async (_, _, _) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(Directory.Exists(initRequest.Base.WorkingDirectory));
                    Assert.IsTrue(File.Exists(Path.Join(initRequest.Base.WorkingDirectory, "Vagrantfile")));
                });
            },
            (provider, _, _) =>
            {
                provider.GetRequiredService<IFilesystem>().TryDirectoryDelete(initRequest.Base.WorkingDirectory!, true);
                Assert.IsFalse(Directory.Exists(initRequest.Base.WorkingDirectory));

                return Task.CompletedTask;
            },
            UnitTest.ServiceProvider!,
            new UnitTest.VsCodeDebugging {Open = false, TellMe = true}
        );
    }

    private async static Task TestInner(
        string debug,
        IRootCommandResponse response,
        List<int> acceptedExitCodes,
        bool outputCanBeEmptyButNotNull = false
    )
    {
        Assert.IsNotNull(response, $"{debug} response is not null");
        Assert.IsNotNull(response.ProcessExecutionResult, $"{debug} response.PER is not null");
        Assert.IsNotNull(response.ProcessExecutionResult.WaitForCompleteExit, $"{debug} response.WaitForCompleteExit");
        Assert.IsNotNull(response.ProcessExecutionResult.OutputStream, $"{debug} response outputsStream");

        await response.ProcessExecutionResult.WaitForCompleteExit;

        response.ProcessExecutionResult.OutputStream.Position = 0;
        var outputReader = new StreamReader(response.ProcessExecutionResult.OutputStream);
        var output = await outputReader.ReadToEndAsync();

        if (response.ProcessExecutionResult.ExitCode is not null)
        {
            var exitCode = (int) response.ProcessExecutionResult.ExitCode;
            if (!acceptedExitCodes.Contains(exitCode))
            {
                throw new ArgumentOutOfRangeException(nameof(exitCode));
            }
        }

        if (outputCanBeEmptyButNotNull)
            Assert.IsNotNull(output, $"{debug} output can be empty but not null");
        else
            Assert.IsTrue(!string.IsNullOrEmpty(output), $"{debug} output is neither empty nor null");
    }

    private class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
    }
}