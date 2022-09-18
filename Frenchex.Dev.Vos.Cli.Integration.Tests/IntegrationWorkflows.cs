﻿using System.CommandLine;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
using static System.Threading.Tasks.Task;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

[TestClass]
[TestCategory(TestCategories.NeedVagrant)]
public class IntegrationWorkflows : IntegrationWorkflowUnitTestForVirtualBox
{
    public static IEnumerable<object[]> Test_Data_MultipleRuns()
    {
        return ProduceDataSets(TimeSpan.FromMinutes(10), "vagrant", 2, 2);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns), DynamicDataSourceType.Method)]
    public async Task TestExecutions(string testCaseName, Payload payload)
    {
        List<Task> tasks = CreateRunInternal(testCaseName, payload, InternalRunExecution);

        await WhenAll(tasks);
    }

    [TestMethod]
    [DynamicData(nameof(Test_Data_MultipleRuns), DynamicDataSourceType.Method)]
    public async Task TestArgumentsParsing(string testCaseName, Payload payload)
    {
        List<Task> tasks = CreateRunInternal(testCaseName, payload, InternalRunParsing);

        await WhenAll(tasks);
    }

    private List<Task> CreateRunInternal(string testCaseName, Payload payload, Func<InputCommand[], string, Task> func)
    {
        var numberOfWorkingDirectories = payload.ListOfListOfCommands!.Count;

        List<string> workingDirectories = new List<string>(numberOfWorkingDirectories);

        foreach (List<InputCommand> num in payload.ListOfListOfCommands)
        {
            workingDirectories.Add(Path.Join(Path.GetTempPath(), Path.GetRandomFileName()));
        }

        List<Task> tasks = new List<Task>();

        var i = 0;
        foreach (List<InputCommand> run in payload.ListOfListOfCommands)
        {
            var commandsRun = func.Invoke(run.ToArray(), workingDirectories[i++]);
            tasks.Add(commandsRun);
        }

        return tasks;
    }

    private async Task InternalRunExecution(InputCommand[] commands, string workingDirectory)
    {
        await RunInternal(new[] {
                workingDirectory
            },
            commands,
            async (command, rootCommand) =>
            {
                var parsed = await rootCommand.InvokeAsync(command);

                Assert.AreEqual(0, parsed);
            },
            false);
    }

    private async Task InternalRunParsing(InputCommand[] commands, string workingDirectory)
    {
        await RunInternal(new[] {
                workingDirectory
            },
            commands,
            (command, rootCommand) =>
            {
                var parsed = rootCommand.Parse(command);

                var msgError = string.Join(Environment.NewLine, parsed.Errors.Select(x => x.Message));

                Assert.AreEqual(0, parsed.Errors.Count, msgError);

                return CompletedTask;
            },
            false);
    }
}