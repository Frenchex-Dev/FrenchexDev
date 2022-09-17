using System.CommandLine;
using Frenchex.Dev.Dotnet.Core.Cli.Integration.Lib.Domain;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

public class IntegrationWorkflowUnitTestForVirtualBox : AbstractUnitTest
{
    private const string WorkingDirectoryMarker = "##{{WORKING_DIRECTORY}}##";

    public static IEnumerable<object[]> ProduceDataSets(
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
                payload.ListOfListOfCommands.Add(ProduceTestData(timeout, vagrantBinPath).ToList());
            }

            listOfList.Add(obj.ToArray());
        }

        return listOfList;
    }

    [TestInitialize]
    public async Task Setup()
    {
        UnitTest = VosCliIntegrationUnitTestBase.CreateUnitTest<ExecutionContext>();

        await UnitTest!.RunAsync<ExecutionContext>(
            (provider, configuration, context, vsCode) =>
            {
                var sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;
                var integration = provider.GetRequiredService<IIntegration>();
                integration.Integrate(sut);

                return Task.CompletedTask;
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            new UnitTest.VsCodeDebugging {TellMe = true});
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

                return Task.CompletedTask;
            },
            false);
    }

    protected static string BuildCommandLineString(
        string command,
        string timeOutOpt,
        string vagrantBingPathOpt
    )
    {
        return $"{command} {timeOutOpt} --working-directory {WorkingDirectoryMarker} {vagrantBingPathOpt}";
    }

    protected static InputCommand[] ProduceTestData(TimeSpan timeout, string vagrantBinPath)
    {
        var timeOutOpt = "--timeout-ms " + timeout.TotalMilliseconds;
        var vagrantBinPathOpt = ""; // $"--vagrant-bin-path {vagrantBinPath}";

        string BuildInternalCommandLineString(string command)
        {
            return BuildCommandLineString(command, timeOutOpt, vagrantBinPathOpt);
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
        bool openVsCode = true
    )
    {
        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
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
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            new UnitTest.VsCodeDebugging {TellMe = true});
    }

    public class Payload
    {
        public string? TestCaseName { get; init; }
        public List<List<InputCommand>>? ListOfListOfCommands { get; init; }
    }
}