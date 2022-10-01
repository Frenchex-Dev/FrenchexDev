using System.CommandLine;
using Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

public class IntegrationWorkflowUnitTestForVirtualBox : AbstractUnitTest
{
    private const string WorkingDirectoryMarker = "##{{WORKING_DIRECTORY}}##";

    protected static IEnumerable<object[]> ProduceDataSets(
        TimeSpan timeout,
        string vagrantBinPath,
        int nbTestCases = 1,
        int nbVosInstances = 3
    )
    {
        List<object[]> listOfList = new List<object[]>();

        for (var i = 0; i < nbTestCases; i++)
        {
            var payload = new Payload {
                TestCaseName = $"Test case {i}",
                ListOfListOfCommands = new List<List<InputCommand>>(nbVosInstances)
            };

            List<object> obj = new List<object> {
                payload.TestCaseName,
                payload
            };

            for (var x = 0; x < nbVosInstances; x++)
            {
                payload.ListOfListOfCommands.Add(ProduceTestData(timeout).ToList());
            }

            listOfList.Add(obj.ToArray());
        }

        return listOfList;
    }

    public async Task SetupUnitTest(UnitTest unitTest, UnitTest.VsCodeDebugging vsCodeDebugging)
    {
        await unitTest.ExecuteAndAssertAsync<ExecutionContext>(
            (provider, _, _, _) =>
            {
                var sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;
                var integration = provider.GetRequiredService<IIntegration>();
                integration.Integrate(sut);

                return Task.CompletedTask;
            },
            (_, _, _) => Task.CompletedTask,
            unitTest.ServiceProvider!,
            vsCodeDebugging);
    }

    public async Task InternalRunParsing(
        InputCommand[] commands,
        string workingDirectory,
        UnitTest.VsCodeDebugging vsCodeDebugging
    )
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

                return Task.CompletedTask;
            },
            vsCodeDebugging);
    }

    private static string BuildCommandLineString(
        string command,
        string timeOutOpt
    )
    {
        return $"{command} {timeOutOpt} --working-directory {WorkingDirectoryMarker}";
    }

    private static InputCommand[] ProduceTestData(TimeSpan timeout)
    {
        var timeOutOpt = "--timeout-ms " + timeout.TotalMilliseconds;

        string BuildInternalCommandLineString(string command)
        {
            return BuildCommandLineString(command, timeOutOpt);
        }

        return new InputCommand[] {
            new("init", BuildInternalCommandLineString("init")),
            new("d.m.t 1",
                BuildInternalCommandLineString(
                    "define machine-type add foo generic/alpine38 4 128 Debian_64 10.9.0 --vram-mb 16 --enabled")),
            new("d.m.t 2",
                BuildInternalCommandLineString(
                    "define machine-type add bar generic/alpine38 4 128 Debian_64 10.9.0 --vram-mb 16 --enabled")),
            new("d.m 1", BuildInternalCommandLineString("define machine add foo foo 4 --enabled ")),
            new("d.m 2", BuildInternalCommandLineString("define machine add bar bar 4 --enabled")),
            new("name", BuildInternalCommandLineString("name bar-0 foo-[2-*]")),
            new("status", BuildInternalCommandLineString("status bar-* foo-[2-*]")),
            new("up foo0", BuildInternalCommandLineString("up foo-0")),
            new("up foo2-*", BuildInternalCommandLineString("up foo-[2-*]")),
            new("status bar* foo2-*", BuildInternalCommandLineString("status bar-* foo-[2-*]")),
            new("halt bar-* foo2-*", BuildInternalCommandLineString("halt bar-* foo-[2-*]")),
            new("destroy foo2", BuildInternalCommandLineString("destroy foo-2 --force")),
            new("destroy all", BuildInternalCommandLineString("destroy --force"))
        };
    }

    protected async Task RunInternal(
        string[] workingDirectories,
        InputCommand[] commands,
        Func<string, RootCommand, Task> execCommand,
        UnitTest.VsCodeDebugging vsCodeDebugging
    )
    {
        await UnitTest!.ExecuteAndAssertAsync<ExecutionContext>(
            async (provider, _, _, _) =>
            {
                var sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;

                foreach (var workingDir in workingDirectories)
                {
                    foreach (var command in commands)
                    {
                        var vosCommand = $"vos {command.Command.Replace(WorkingDirectoryMarker, workingDir)}";
                        await execCommand(vosCommand, sut);
                    }
                }
            },
            (_, _, _) => Task.CompletedTask,
            UnitTest.ServiceProvider!,
            vsCodeDebugging);
    }

    public class Payload
    {
        public string? TestCaseName { get; init; }
        public List<List<InputCommand>>? ListOfListOfCommands { get; init; }
    }
}