#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using System.CommandLine;
using static System.Threading.Tasks.Task;

#endregion

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

[TestClass]
[TestCategory(TestCategories.NeedVagrant)]
public class VosCliIntegrationWorkflowTests : IntegrationWorkflowUnitTestForVirtualBox
{
    public static IEnumerable<object[]> Test_Data_MultipleRuns()
    {
        return ProduceDataSets("10m", "vagrant", 2, 2);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns), DynamicDataSourceType.Method)]
    public async Task TestExecutions_MultipleRuns(string testCaseName, Payload payload)
    {
        List<Task>? tasks =
            await CreateRunInternal(testCaseName, payload, InternalRunExecution, new UnitTest.VsCodeDebugging(), VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext>());

        await WhenAll(tasks);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns), DynamicDataSourceType.Method)]
    public async Task TestArgumentsParsing_MultipleRuns(string testCaseName, Payload payload)
    {
        List<Task>? tasks = await CreateRunInternal(testCaseName, payload, InternalRunParsing, new UnitTest.VsCodeDebugging(), VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext>());

        await WhenAll(tasks);
    }

    public static IEnumerable<object[]> Test_Data_SingleRun()
    {
        return ProduceDataSets("10m", "vagrant", 1, 1);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_SingleRun), DynamicDataSourceType.Method)]
    public async Task TestExecutions_SingleRun(string testCaseName, Payload payload)
    {
        List<Task>? tasks =
            await CreateRunInternal(testCaseName, payload, InternalRunExecution, new UnitTest.VsCodeDebugging(), VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext>());

        await WhenAll(tasks);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_SingleRun), DynamicDataSourceType.Method)]
    public async Task TestArgumentsParsing_SingleRun(string testCaseName, Payload payload)
    {
        List<Task>? tasks = await CreateRunInternal(testCaseName, payload, InternalRunParsing, new UnitTest.VsCodeDebugging(), VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext>());

        await WhenAll(tasks);
    }

    private async Task<List<Task>> CreateRunInternal(
        string testCaseName,
        Payload payload,
        Func<InputCommand[], string, UnitTest.VsCodeDebugging, UnitTest, Task> func,
        UnitTest.VsCodeDebugging vsCodeDebugging,
        UnitTest unitTest
    )
    {
        unitTest.BuildIfNecessary();
        await SetupUnitTest(unitTest, vsCodeDebugging);

        var numberOfWorkingDirectories = payload.ListOfListOfCommands!.Count;

        List<string> workingDirectories = new(numberOfWorkingDirectories);

        foreach (List<InputCommand>? num in payload.ListOfListOfCommands)
            workingDirectories.Add(Path.Join(Path.GetTempPath(), Path.GetRandomFileName()));

        List<Task> tasks = new();

        var i = 0;

        foreach (List<InputCommand>? run in payload.ListOfListOfCommands)
        {
            var commandsRun = func.Invoke(run.ToArray(), workingDirectories[i++], vsCodeDebugging, unitTest);
            tasks.Add(commandsRun);
        }

        return tasks;
    }

    private async Task InternalRunExecution(
        InputCommand[] commands,
        string workingDirectory,
        UnitTest.VsCodeDebugging vsCodeDebugging,
        UnitTest unitTest
    )
    {
        await RunInternal(new[]
            {
                workingDirectory
            },
            commands,
            async (command, rootCommand) =>
            {
                var parsed = await rootCommand.InvokeAsync(command);

                Assert.AreEqual(0, parsed);
            },
            vsCodeDebugging,
            unitTest
        );
    }
}