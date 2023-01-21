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
public class MultipleRuns_OneMachineType_MultipleMachines : IntegrationWorkflowUnitTestForVirtualBox
{
    public static IEnumerable<object[]> Test_Data_MultipleRuns_OneMachineType_MultipleMachines()
    {
        return ProduceDataSets("10m", ProduceTestData_OneMachineType_MultipleMachines, 2, 2);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns_OneMachineType_MultipleMachines), DynamicDataSourceType.Method)]
    public async Task TestExecutions_MultipleRuns_OneMachineType_MultipleMachines(string testCaseName, Payload payload)
    {
        var tasks =
            await CreateRunInternal(payload, InternalRunExecution,
                new UnitTest.VsCodeDebugging { Open = true, OpenAuto = false },
                VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext, SubjectUnderTest>());

        await Task.WhenAll(tasks);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns_OneMachineType_MultipleMachines), DynamicDataSourceType.Method)]
    public async Task TestArgumentsParsing_MultipleRuns_OneMachineType_MultipleMachines(string testCaseName,
        Payload payload)
    {
        var tasks = await CreateRunInternal(payload, InternalRunParsing, new UnitTest.VsCodeDebugging(),
            VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext, SubjectUnderTest>());

        await Task.WhenAll(tasks);
    }
}