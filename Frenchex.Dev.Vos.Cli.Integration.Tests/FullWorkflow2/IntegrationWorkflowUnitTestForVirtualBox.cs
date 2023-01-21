#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;
using System.CommandLine.Parsing;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests.FullWorkflow2;

public class IntegrationWorkflowUnitTestForVirtualBox : AbstractUnitTest
{
    protected const string BoxTest = "generic/alpine317";
    protected const string BoxVersionTest = "4.2.8";

    protected const string WorkingDirectoryMarker = "##{{WORKING_DIRECTORY}}##";

    protected static IEnumerable<object[]> ProduceDataSets(
        string timeout,
        Func<string, InputCommand[]> dataTestProducerFunc,
        int nbTestCases = 1,
        int nbVosInstances = 3
    )
    {
        var listOfList = new List<object[]>();

        for (var i = 0; i < nbTestCases; i++)
        {
            var payload = new Payload
            {
                TestCaseName = $"Test case {i}",
                ListOfListOfCommands = new List<List<InputCommand>>(nbVosInstances)
            };

            var obj = new List<object>
            {
                payload.TestCaseName,
                payload
            };

            for (var x = 0; x < nbVosInstances; x++)
                payload.ListOfListOfCommands.Add(dataTestProducerFunc(timeout).ToList());

            listOfList.Add(obj.ToArray());
        }

        return listOfList;
    }

    public static async Task SetupUnitTest(UnitTest unitTest, UnitTest.VsCodeDebugging vsCodeDebugging)
    {
        await unitTest.ExecuteAndAssertAsync<ExecutionContext>(
            (provider, _, _, _) =>
            {
                RootCommand sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;
                var integration = provider.GetRequiredService<IIntegration>();
                integration.Integrate(sut);

                return Task.CompletedTask;
            },
            (_, _, _) => Task.CompletedTask,
            unitTest.GetScopedServiceProvider(),
            vsCodeDebugging);
    }

    public static async Task InternalRunParsing(
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
            (commandName, command, rootCommand) =>
            {
                ParseResult parsed = rootCommand.Parse(command);

                string msgError = string.Join(Environment.NewLine, parsed.Errors.Select(x => x.Message));

                Assert.AreEqual(0, parsed.Errors.Count, $"{commandName}: {msgError} : {command}");

                return Task.CompletedTask;
            },
            vsCodeDebugging,
            unitTest
        );
    }

    protected static string BuildCommandLineString(
        string command,
        string timeOutOpt
    )
    {
        return $"{command} {timeOutOpt} --working-directory {WorkingDirectoryMarker}";
    }

    protected static InputCommand[] ProduceTestData_OneMachineType_MultipleMachines(string timeout)
    {
        string? timeOutOpt = "--timeout " + timeout;

        string BuildInternalCommandLineString(string command)
        {
            return BuildCommandLineString(command, timeOutOpt);
        }

        return new[]
        {
            new("init", BuildInternalCommandLineString("init")),
            new InputCommand("d.m.t 1",
                BuildInternalCommandLineString(
                    $"define machine-type add foo {BoxTest} {BoxVersionTest} 4 128 Linux_64  --vram-mb 16 --enabled")),
            new InputCommand("d.m 1",
                BuildInternalCommandLineString("define machine add foo foo 4 --enabled --primary")),
            new InputCommand("name without quotes", BuildInternalCommandLineString("name foo-[2-*]")),
            new InputCommand("name with quotes", BuildInternalCommandLineString("name 'foo-[2-*]'")),
            new InputCommand("status", BuildInternalCommandLineString("status foo-[2-*]")),
            new InputCommand("up foo-0", BuildInternalCommandLineString("up foo-0")),
            new InputCommand("up foo2-*", BuildInternalCommandLineString("up foo-[2-*]")),
            new InputCommand("status bar* foo2-*", BuildInternalCommandLineString("status foo-[2-*]")),
            new InputCommand("halt bar-* foo2-*", BuildInternalCommandLineString("halt foo-[2-*]")),
            new InputCommand("destroy foo2", BuildInternalCommandLineString("destroy foo-0 --force")),
            new InputCommand("destroy all", BuildInternalCommandLineString("destroy --force"))
        };
    }


    protected static async Task RunInternal(
        string[] workingDirectories,
        InputCommand[] commands,
        Func<string, string, RootCommand, Task> execCommand,
        UnitTest.VsCodeDebugging vsCodeDebugging,
        UnitTest unitTest
    )
    {
        await unitTest.ExecuteAndAssertAsync<ExecutionContext>(
            async (provider, _, _, openVsCodeDebugging) =>
            {
                RootCommand sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;
                var vsCodeStarted = false;
                foreach (string workingDir in workingDirectories)
                foreach (InputCommand command in commands)
                {
                    var vosCommand = $"{command.Command.Replace(WorkingDirectoryMarker, workingDir)}";
                    await execCommand(command.Name, vosCommand, sut);

                    if (!vsCodeStarted && vsCodeDebugging.Open)
                    {
                        vsCodeStarted = true;
                        openVsCodeDebugging(workingDir);
                    }
                }

                vsCodeDebugging.Stop();
            },
            (_, _, _) => Task.CompletedTask,
            unitTest.GetScopedServiceProvider(),
            vsCodeDebugging);
    }

    protected static async Task<List<Task>> CreateRunInternal(
        Payload payload,
        Func<InputCommand[], string, UnitTest.VsCodeDebugging, UnitTest, Task> func,
        UnitTest.VsCodeDebugging vsCodeDebugging,
        UnitTest unitTest
    )
    {
        unitTest.BuildIfNecessary();
        await SetupUnitTest(unitTest, vsCodeDebugging);

        int numberOfWorkingDirectories = payload.ListOfListOfCommands!.Count;

        var workingDirectories = new List<string>(numberOfWorkingDirectories);

        foreach (var _ in payload.ListOfListOfCommands)
            workingDirectories.Add(Path.Join(Path.GetTempPath(), Path.GetRandomFileName()));

        var tasks = new List<Task>();

        var i = 0;

        foreach (var run in payload.ListOfListOfCommands)
        {
            Task commandsRun = func.Invoke(run.ToArray(), workingDirectories[i++], vsCodeDebugging, unitTest);
            tasks.Add(commandsRun);
        }

        return tasks;
    }

    protected async Task InternalRunExecution(
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
            async (commandName, command, rootCommand) =>
            {
                int parsed = await rootCommand.InvokeAsync(command);

                Assert.AreEqual(0, parsed, $"{commandName}: {command}");
            },
            vsCodeDebugging,
            unitTest
        );
    }

    public class Payload
    {
        public string? TestCaseName { get; init; }
        public List<List<InputCommand>>? ListOfListOfCommands { get; init; }
    }
}