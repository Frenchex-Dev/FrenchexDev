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
public class CompleteWorkflowTests : AbstractUnitTest
{
    public static IEnumerable<object[]> DataSource()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();

        var sp = UnitTest.ServiceProvider!;

        var alpineInstallDockerCommand = @"#!/usr/bin/env bash

apk update
apk add docker docker-compose
rc-update add docker default
        ";

        sp.GetRequiredService<IFilesystem>()
            .FileWriteAllTextAsync(Path.Join("Provisioning", "docker.install.sh"), alpineInstallDockerCommand);

        yield return new object[] {
            (string workingDirectory) => sp
                .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IInitCommandRequestBuilder>()
                .UsingBoxName("generic/alpine38")
                .UsingBoxVersion("4.1.10")
                .Build(),
            (string workingDirectory) => sp
                .GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(10).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IUpCommandRequestBuilder>()
                .WithProvision(false)
                .Build(),
            (string workingDirectory) =>
            {
                var factory = 
                sp
                    .GetRequiredService<IProvisionCommandRequestBuilderFactory>();

                var builder = factory.Factory();

                builder.BaseBuilder
                    .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                    .UsingWorkingDirectory(workingDirectory);

                builder.ProvisionWith(new[] {"docker.install"});
                
                return builder.Build(); 
            },
            (string workingDirectory) => sp
                .GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IStatusCommandRequestBuilder>()
                .Build(),
            (string workingDirectory) => sp
                .GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingName("default")
                .Build(),
            (string workingDirectory) => sp
                .GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(1).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<ISshCommandRequestBuilder>()
                .UsingCommand("echo foo")
                .UsingNameOrId("default")
                .Build(),
            (string workingDirectory) => sp
                .GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(3).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IHaltCommandRequestBuilder>()
                .Build(),
            (string workingDirectory) => sp
                .GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingTimeoutMiliseconds((int) TimeSpan.FromMinutes(3).TotalMilliseconds)
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .Build()
        };
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    public async Task Test_Complete_Workflow(
        Func<string, IInitCommandRequest> initRequestBuilder,
        Func<string, IUpCommandRequest> upRequestBuilder,
        Func<string, IProvisionCommandRequest> provisionRequestBuilder,
        Func<string, IStatusCommandRequest> statusRequestBuilder,
        Func<string, ISshConfigCommandRequest> sshConfigCommandRequestBuilder,
        Func<string, ISshCommandRequest> sshCommandRequestBuilder,
        Func<string, IHaltCommandRequest> haltRequestBuilder,
        Func<string, IDestroyCommandRequest> destroyRequestBuilder
    )
    {
        // directory is created by Init command
        var workingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        var initRequest = initRequestBuilder.Invoke(workingDirectory);
        var upRequest = upRequestBuilder.Invoke(workingDirectory);
        var provisionRequest = provisionRequestBuilder.Invoke(workingDirectory);
        var statusRequest = statusRequestBuilder.Invoke(workingDirectory);
        var sshConfigCommandRequest = sshConfigCommandRequestBuilder.Invoke(workingDirectory);
        var sshCommandRequest = sshCommandRequestBuilder.Invoke(workingDirectory);
        var haltRequest = haltRequestBuilder.Invoke(workingDirectory);
        var destroyRequest = destroyRequestBuilder.Invoke(workingDirectory);
        
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
}

public class ExecutionContext : WithWorkingDirectoryExecutionContext
{
}