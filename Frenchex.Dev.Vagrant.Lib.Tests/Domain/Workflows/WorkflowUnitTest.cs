using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

[TestClass]
public class CompleteWorkflowTests : AbstractUnitTest
{
    public static IEnumerable<object[]> DataSource()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();

        // directory is created by Init command
        var tempDir = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        yield return new object[] {
            UnitTest!.ServiceProvider!
                .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<IInitCommandRequestBuilder>()
                .UsingBoxName("generic/alpine38")
                .UsingBoxVersion("4.1.10")
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(10).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<IUpCommandRequestBuilder>()
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<IStatusCommandRequestBuilder>()
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingName("default")
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<ISshCommandRequestBuilder>()
                .UsingCommand("echo foo")
                .UsingNameOrId("default")
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(3).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<IHaltCommandRequestBuilder>()
                .Build(),
            UnitTest!.ServiceProvider!
                .GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(3).TotalMilliseconds)
                .UsingWorkingDirectory(tempDir)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .Build()
        };
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    public async Task Test_Complete_Workflow(
        IInitCommandRequest initRequest,
        IUpCommandRequest upRequest,
        IStatusCommandRequest statusRequest,
        ISshConfigCommandRequest sshConfigCommandRequest,
        ISshCommandRequest sshCommandRequest,
        IHaltCommandRequest haltRequest,
        IDestroyCommandRequest destroyRequest
    )
    {
        await UnitTest!.RunAsync<ExecutionContext>(async (provider, root, context, vsCode) =>
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
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(Directory.Exists(initRequest.Base.WorkingDirectory));
                    Assert.IsTrue(File.Exists(Path.Join(initRequest.Base.WorkingDirectory, "Vagrantfile")));
                });
            },
            (provider, root, context) =>
            {
                provider.GetRequiredService<IFilesystem>().TryDirectoryDelete(initRequest.Base.WorkingDirectory!, true);
                Assert.IsFalse(Directory.Exists(initRequest.Base.WorkingDirectory));

                return Task.CompletedTask;
            },
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
        Assert.IsNotNull(response.ProcessExecutionResult.WaitForCompleteExit, $"{debug} response.WaitForComplexeExit");
        Assert.IsNotNull(response.ProcessExecutionResult.OutputStream, $"{debug} response outputstream");

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

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
    }
}