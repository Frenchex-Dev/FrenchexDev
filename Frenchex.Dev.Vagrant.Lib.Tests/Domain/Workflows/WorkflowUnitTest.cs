#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Filesystem.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Command;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Command;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows.WorkflowData;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

[TestClass]
public class VagrantLibCompleteWorkflowTests : AbstractUnitTest
{
    public static IEnumerable<object[]> DataSource()
    {
        yield return new object[]
        {
            new VagrantLibWorkflowDataBuilderData1()
        };
    }

    [TestInitialize]
    public void TestInit()
    {
        UnitTest = VagrantUnitTestBase.CreateUnitTest<ExecutionContext>();
        GetUnitTest().BuildIfNecessary();
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    [TestCategory(TestCategories.NeedVagrant)]
    public async Task Test_Complete_Workflow(
        IVagrantLibWorkflowDataBuilder payloadBuilderPayload
    )
    {
        var workingDirectory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
        var sp = GetUnitTest().GetScopedServiceProvider();

        var payloadBuilder = new PayloadBuilder();
        var payload = payloadBuilderPayload.Build(workingDirectory, sp);

        if (sp == null)
            throw new ArgumentNullException(nameof(sp));

        var initRequest = payloadBuilder.InitCommandRequestBuilder.Invoke(payload.InitCommandRequestBuilderPayload!);
        var upRequest = payloadBuilder.UpCommandRequestBuilder.Invoke(payload.UpCommandRequestBuilderPayload!);
        var provisionRequest =
            payloadBuilder.ProvisionCommandRequestBuilder.Invoke(payload.ProvisionCommandRequestBuilderPayload!);

        var statusRequest =
            payloadBuilder.StatusCommandRequestBuilder.Invoke(payload.StatusCommandRequestBuilderPayload!);

        var sshConfigCommandRequest =
            payloadBuilder.SshConfigCommandRequestBuilder.Invoke(payload.SshConfigCommandRequestBuilderPayload!);

        var sshCommandRequest =
            payloadBuilder.SshCommandRequestBuilder.Invoke(payload.SshCommandRequestBuilderPayload!);

        var haltRequest = payloadBuilder.HaltCommandRequestBuilder.Invoke(payload.HaltCommandRequestBuilderPayload!);
        var destroyRequest =
            payloadBuilder.DestroyCommandRequestBuilder.Invoke(payload.DestroyCommandRequestBuilderPayload!);

        await GetUnitTest().ExecuteAndAssertAndCleanupAsync<ExecutionContext>(async (provider, _, _, _) =>
            {
                await TestInner(
                    "init",
                    provider.GetRequiredService<IInitCommand>().StartProcess(initRequest),
                    new List<int> { 0, 1 },
                    true);

                // vsCode.Invoke(initRequest.Base.WorkingDirectory!);

                await TestInner(
                    "status",
                    provider.GetRequiredService<IStatusCommand>().StartProcess(statusRequest),
                    new List<int> { 0 },
                    true
                );

                await TestInner(
                    "up",
                    provider.GetRequiredService<IUpCommand>().StartProcess(upRequest),
                    new List<int> { 0 },
                    true
                );

                await TestInner(
                    "provision",
                    provider.GetRequiredService<IProvisionCommand>().StartProcess(provisionRequest),
                    new List<int> { 0, 1 },
                    true
                );

                await TestInner("ssh-config",
                    provider.GetRequiredService<ISshConfigCommand>().StartProcess(sshConfigCommandRequest),
                    new List<int> { 0 },
                    true
                );

                await TestInner(
                    "ssh",
                    provider.GetRequiredService<ISshCommand>().StartProcess(sshCommandRequest),
                    new List<int> { 0 },
                    true
                );

                await TestInner(
                    "halt",
                    provider.GetRequiredService<IHaltCommand>().StartProcess(haltRequest),
                    new List<int> { 0 },
                    true
                );

                await TestInner(
                    "destroy",
                    provider.GetRequiredService<IDestroyCommand>().StartProcess(destroyRequest),
                    new List<int> { 0 },
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
            GetUnitTest().GetScopedServiceProvider(),
            new UnitTest.VsCodeDebugging { Open = false, TellMe = true }
        );
    }

    private static async Task TestInner(
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
            var exitCode = (int)response.ProcessExecutionResult.ExitCode;
            if (!acceptedExitCodes.Contains(exitCode)) throw new ArgumentOutOfRangeException(nameof(exitCode));
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