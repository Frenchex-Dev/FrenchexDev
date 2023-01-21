#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests.FullWorkflow2;

[TestClass]
[TestCategory(TestCategories.NeedVagrant)]
public class SingleRunOneMachineTypeOneMachineProvisioningDockerCeInstall : IntegrationWorkflowUnitTestForVirtualBox
{
    public static InputCommand[] ProduceTestData_OneMachineType_OneMachine_ProvisioningDockerCeInstallPrivileged(
        string timeout)
    {
        var timeOutOpt = $"--timeout {timeout}";

        string BuildInternalCommandLineString(string command)
        {
            return BuildCommandLineString(command, timeOutOpt);
        }

        return new[]
        {
            new InputCommand("init", BuildInternalCommandLineString("init")),
            new InputCommand("d.m.t 1",
                BuildInternalCommandLineString(
                    $"define machine-type add foo {BoxTest} {BoxVersionTest} 4 128 Linux_64  --vram-mb 16 --enabled")),
            new InputCommand("d.m 1",
                BuildInternalCommandLineString("define machine add foo foo 1 --enabled --primary")),
            new InputCommand("d.p.m 1",
                BuildInternalCommandLineString(
                    "define provisioning map foo docker-ce/install v1 --machine-type --enabled --privileged")),
            new InputCommand("status", BuildInternalCommandLineString("status foo-*")),
            new InputCommand("up foo-0", BuildInternalCommandLineString("up foo-0 --provision false")),
            new InputCommand("provision",
                BuildInternalCommandLineString("provision foo-0 --provision-with docker-ce/install")),
            new InputCommand("halt", BuildInternalCommandLineString("halt foo-*")),
            new InputCommand("destroy all", BuildInternalCommandLineString("destroy --force"))
        };
    }

    public static IEnumerable<object[]> Test_Data_SingleRun_OneMachineType_OneMachine_ProvisioningDockerCeInstall()
    {
        return ProduceDataSets("10m", ProduceTestData_OneMachineType_OneMachine_ProvisioningDockerCeInstallPrivileged,
            1, 1);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_SingleRun_OneMachineType_OneMachine_ProvisioningDockerCeInstall),
        DynamicDataSourceType.Method)]
    public async Task TestExecutions_SingleRun_OneMachineType_OneMachine_ProvisioningDockerCeInstall(
        string testCaseName, Payload payload)
    {
        var tasks = await CreateRunInternal(payload, InternalRunExecution,
            new UnitTest.VsCodeDebugging { Open = true, OpenAuto = false },
            VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext, SubjectUnderTest>());

        await Task.WhenAll(tasks);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_SingleRun_OneMachineType_OneMachine_ProvisioningDockerCeInstall),
        DynamicDataSourceType.Method)]
    public async Task TestArgumentsParsing_SingleRun_OneMachineType_OneMachine_ProvisioningDockerCeInstall(
        string testCaseName, Payload payload)
    {
        var tasks = await CreateRunInternal(payload, InternalRunParsing, new UnitTest.VsCodeDebugging(),
            VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext, SubjectUnderTest>());

        await Task.WhenAll(tasks);
    }
}