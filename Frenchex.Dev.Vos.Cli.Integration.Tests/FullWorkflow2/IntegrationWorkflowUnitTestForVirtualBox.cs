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
using Frenchex.Dev.Vos.Cli.IntegrationLib.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests.FullWorkflow2;

public class IntegrationWorkflowUnitTestForVirtualBox : AbstractUnitTest
{
    private const string BoxTest = "generic/alpine317";
    private const string BoxVersionTest = "4.2.8";

    private const string WorkingDirectoryMarker = "##{{WORKING_DIRECTORY}}##";

    protected static IEnumerable<object[]> ProduceDataSets(
        string timeout,
        int nbTestCases = 1,
        int nbVosInstances = 3
    )
    {
        List<object[]> listOfList = new();

        for (var i = 0; i < nbTestCases; i++)
        {
            var payload = new Payload
            {
                TestCaseName = $"Test case {i}",
                ListOfListOfCommands = new List<List<InputCommand>>(nbVosInstances)
            };

            List<object> obj = new()
            {
                payload.TestCaseName,
                payload
            };

            for (var x = 0; x < nbVosInstances; x++)
                payload.ListOfListOfCommands.Add(ProduceTestData(timeout).ToList());

            listOfList.Add(obj.ToArray());
        }

        return listOfList;
    }

    public static async Task SetupUnitTest(UnitTest unitTest, UnitTest.VsCodeDebugging vsCodeDebugging)
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
            (command, rootCommand) =>
            {
                var parsed = rootCommand.Parse(command);

                var msgError = string.Join(Environment.NewLine, parsed.Errors.Select(x => x.Message));

                Assert.AreEqual(0, parsed.Errors.Count, msgError);

                return Task.CompletedTask;
            },
            vsCodeDebugging,
            unitTest
        );
    }

    private static string BuildCommandLineString(
        string command,
        string timeOutOpt
    )
    {
        return $"{command} {timeOutOpt} --working-directory {WorkingDirectoryMarker}";
    }

    private static InputCommand[] ProduceTestData(string timeout)
    {
        var timeOutOpt = "--timeout " + timeout;

        string BuildInternalCommandLineString(string command)
        {
            return BuildCommandLineString(command, timeOutOpt);
        }

        return new InputCommand[]
        {
            new("init", BuildInternalCommandLineString("init")),
            new("d.m.t 1", BuildInternalCommandLineString($"define machine-type add foo ${BoxTest} 4 128 Linux_64 ${BoxVersionTest} --vram-mb 16 --enabled")),
            new("d.m 1", BuildInternalCommandLineString("define machine add foo foo 4 --enabled ")),
            new("d.m 1", BuildInternalCommandLineString("define provisioning map foo 'docker-ce/install' v1 --machine-type --enabled")),
            new("name", BuildInternalCommandLineString("name 'foo-[2-*]'")),
            new("status", BuildInternalCommandLineString("status 'foo-[2-*]'")),
            new("up foo0", BuildInternalCommandLineString("up 'foo-0'")),
            new("up foo2-*", BuildInternalCommandLineString("up 'foo-[2-*]'")),
            new("status bar* foo2-*", BuildInternalCommandLineString("status 'foo-[2-*]'")),
            new("provision", BuildInternalCommandLineString("provision 'foo-0' --provision-with 'docker-ce/install'")),
            new("halt bar-* foo2-*", BuildInternalCommandLineString("halt 'foo-[2-*]'")),
            new("destroy foo2", BuildInternalCommandLineString("destroy 'foo-0' --force")),
            new("destroy all", BuildInternalCommandLineString("destroy --force"))
        };
    }

    protected static async Task RunInternal(
        string[] workingDirectories,
        InputCommand[] commands,
        Func<string, RootCommand, Task> execCommand,
        UnitTest.VsCodeDebugging vsCodeDebugging,
        UnitTest unitTest
    )
    {
        await unitTest.ExecuteAndAssertAsync<ExecutionContext>(
            async (provider, _, _, _) =>
            {
                var sut = provider.GetRequiredService<SubjectUnderTest>().RootCommand;
                vsCodeDebugging.Start();
                foreach (var workingDir in workingDirectories)
                    foreach (var command in commands)
                    {
                        var vosCommand = $"{command.Command.Replace(WorkingDirectoryMarker, workingDir)}";
                        await execCommand(vosCommand, sut);
                    }
            },
            (_, _, _) => Task.CompletedTask,
            unitTest.GetScopedServiceProvider(),
            vsCodeDebugging);
    }

    public class Payload
    {
        public string? TestCaseName { get; init; }
        public List<List<InputCommand>>? ListOfListOfCommands { get; init; }
    }
}