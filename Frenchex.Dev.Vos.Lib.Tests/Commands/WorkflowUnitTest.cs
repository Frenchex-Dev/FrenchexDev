using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Lib.Domain.Actions.Networking;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Name;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Tests.Commands;

[TestClass]
public class CompleteWorkflowTests1 : AbstractUnitTest
{
    private const string BoxTest = "generic/alpine316";
    private const string BoxVersionTest = "4.1.10";

    public static IEnumerable<object[]> DataSource()
    {
        UnitTest = VosUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();

        var tempDir = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

        yield return new[] {
            BuildInitCommandRequest(tempDir),
            BuildDefineMachineTypeAddCommandRequestsList(tempDir),
            BuildDefineMachineAddCommandRequestsList(tempDir),
            BuildNameCommandRequestsList(tempDir),
            BuildStatusBeforeUpCommandRequestsList(tempDir),
            BuildUpCommandRequestsList(tempDir),
            BuildStatusAfterUpCommandRequestsList(tempDir),
            BuildSshConfigCommandRequestsList(tempDir),
            BuildSshCommandRequestsList(tempDir),
            BuildHaltCommandRequestsList(tempDir),
            BuildDestroyCommandRequestsList(tempDir)
        };
    }

    [TestCleanup]
    public async Task CleanUp()
    {
        await Task.Run(() =>
        {
            UnitTest?.DisposeAsync();
        });
    }

    [TestMethod]
    [DynamicData(nameof(DataSource), DynamicDataSourceType.Method)]
    [TestCategory("need-vagrant")]
    public async Task Test_Complete_Workflow(
        IInitCommandRequest initRequest,
        IList<IDefineMachineTypeAddCommandRequest> defineMachineTypeAddCommandRequestsList,
        IList<IDefineMachineAddCommandRequest> defineMachineAddCommandRequestsList,
        IList<INameCommandRequest> nameCommandRequestsList,
        IList<IStatusCommandRequest> statusBeforeUpCommandRequestsList,
        IList<IUpCommandRequest> upRequestsList,
        IList<IStatusCommandRequest> statusAfterUpCommandRequestsList,
        IList<ISshConfigCommandRequest> sshConfigCommandRequestsList,
        IList<ISshCommandRequest> sshCommandRequestsList,
        IList<IHaltCommandRequest> haltRequestsList,
        IList<IDestroyCommandRequest> destroyRequestsLists
    )
    {
        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                await Task.Run(() =>
                {
                    context.WorkingDirectory = initRequest.Base.WorkingDirectory;

                    var initCommand = provider.GetRequiredService<IInitCommand>();
                    context.InitCommandResponse = initCommand.Execute(initRequest);

                    vsCode.Invoke(initRequest.Base.WorkingDirectory!);
                });
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in defineMachineTypeAddCommandRequestsList)
                {
                    await provider.GetRequiredService<IDefineMachineTypeAddCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in defineMachineAddCommandRequestsList)
                {
                    await provider.GetRequiredService<IDefineMachineAddCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in nameCommandRequestsList)
                {
                    var response = await provider.GetRequiredService<INameCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in statusBeforeUpCommandRequestsList)
                {
                    var statusResponse = await provider.GetRequiredService<IStatusCommand>().Execute(item);
                    Assert.IsNotNull(statusResponse, "got status response");
                    Assert.IsTrue(statusResponse.Statuses.Any(), "got machines in status response");

                    foreach (KeyValuePair<string, (string, VagrantMachineStatusEnum)> statusItem in statusResponse
                                 .Statuses)
                    {
                        Assert.IsTrue(statusItem.Value.ToString()
                            .Contains(VagrantMachineStatusEnum.NotCreated.ToString()));
                    }
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                List<string> willBeUp = new();

                foreach (var item in upRequestsList)
                {
                    var upResponse = await provider.GetRequiredService<IUpCommand>().Execute(item);
                    Assert.IsNotNull(upResponse.Response);
                    Assert.IsNotNull(upResponse.Response.ProcessExecutionResult.WaitForCompleteExit);
                    var consoleOutputStream = new StreamWriter(Console.OpenStandardOutput());
                    consoleOutputStream.AutoFlush = true;
                    Console.SetOut(consoleOutputStream);
                    await upResponse.Response.ProcessExecutionResult.WaitForCompleteExit;


                    Assert.IsTrue(
                        new List<int> {0, 1}.Contains((int) upResponse.Response.ProcessExecutionResult.ExitCode!),
                        "up exit code is zero");

                    var realNames = await provider.GetRequiredService<INameCommand>().Execute(
                        provider.GetRequiredService<INameCommandRequestBuilderFactory>().Factory()
                            .BaseBuilder
                            .UsingWorkingDirectory(item.Base.WorkingDirectory)
                            .Parent<INameCommandRequestBuilder>()
                            .WithNames(item.Names)
                            .Build());

                    willBeUp.AddRange(realNames.Names);

                    foreach (var subItem in statusAfterUpCommandRequestsList)
                    {
                        var statusResponse = await provider.GetRequiredService<IStatusCommand>().Execute(subItem);
                        Assert.IsNotNull(statusResponse);
                        Assert.IsTrue(statusResponse.Statuses.Any());

                        foreach (var (key, value) in statusResponse.Statuses)
                        {
                            Assert.IsTrue(value.ToString().Contains(
                                willBeUp.Contains(key)
                                    ? VagrantMachineStatusEnum.Running.ToString()
                                    : VagrantMachineStatusEnum.NotCreated.ToString()));
                        }
                    }
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshConfigCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshConfigCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshConfigCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshConfigCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in haltRequestsList)
                {
                    await provider.GetRequiredService<IHaltCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in destroyRequestsLists)
                {
                    await provider.GetRequiredService<IDestroyCommand>().Execute(item);
                }
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Assert.IsTrue(Directory.Exists(initRequest.Base.WorkingDirectory));
                    Assert.IsTrue(File.Exists(Path.Join(initRequest.Base.WorkingDirectory, "Vagrantfile")));
                });
            },
            async (provider, root, context) =>
            {
                await Task.Run(() =>
                {
                    Directory.Delete(context.WorkingDirectory!, true);
                    Assert.IsFalse(Directory.Exists(initRequest.Base.WorkingDirectory));
                });
            });

        /** Template **/

        await UnitTest!.RunAsync<ExecutionContext>(
#pragma warning disable CS1998
            async (provider, configuration, context, vsCode) =>
#pragma warning restore CS1998
            {
            },
#pragma warning disable CS1998
            async (provider, root, context) =>
#pragma warning restore CS1998
            {
            },
            (provider, root, context) => Task.CompletedTask);

        /** Template **/
    }

    private static List<IStatusCommandRequest> BuildStatusAfterUpCommandRequestsList(string? tempDir)
    {
        return new List<IStatusCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"foo-0", "foo-1"})
                .Build(),
            UnitTest.ServiceProvider!.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-1"})
                .Build(),
            UnitTest.ServiceProvider!.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-0"})
                .Build(),
            UnitTest.ServiceProvider!.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IStatusCommandRequestBuilder>()
                .WithNames(new[] {"bar-[0-*]", "foo-[0-*]"})
                .Build()
        };
    }

    private static List<IStatusCommandRequest> BuildStatusBeforeUpCommandRequestsList(string? tempDir)
    {
        return new List<IStatusCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IStatusCommandRequestBuilder>()
                .Build()
        };
    }

    private static List<IDestroyCommandRequest> BuildDestroyCommandRequestsList(string? tempDir)
    {
        return new List<IDestroyCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .UsingName("foo-0")
                .Build(),
            UnitTest.ServiceProvider!.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .UsingName("foo-1")
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IDestroyCommandRequestBuilder>()
                .WithForce(true)
                .Build()
        };
    }

    private static List<IHaltCommandRequest> BuildHaltCommandRequestsList(string? tempDir)
    {
        return new List<IHaltCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IHaltCommandRequestBuilder>()
                .UsingNames(new[] {"foo-0", "foo-1"})
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IHaltCommandRequestBuilder>()
                .UsingNames(new[] {"bar-0"})
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IHaltCommandRequestBuilder>()
                .Build()
        };
    }

    private static List<ISshCommandRequest> BuildSshCommandRequestsList(string? tempDir)
    {
        return new List<ISshCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<ISshCommandRequestBuilder>()
                .UsingNames(new[] {"foo-1"})
                .UsingCommands(new[] {"echo foo"})
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<ISshCommandRequestBuilder>()
                .UsingNames(new[] {"bar-0"})
                .UsingCommands(new[] {"echo bar"})
                .Build()
        };
    }

    private static List<ISshConfigCommandRequest> BuildSshConfigCommandRequestsList(string? tempDir)
    {
        return new List<ISshConfigCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingNamesOrIds(new[] {
                    "foo-0"
                })
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<ISshConfigCommandRequestBuilder>()
                .UsingNamesOrIds(new[] {
                    "bar-1"
                })
                .Build()
        };
    }

    private static List<IUpCommandRequest> BuildUpCommandRequestsList(string? tempDir)
    {
        return new List<IUpCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IUpCommandRequestBuilder>()
                .UsingNames(new[] {"foo-0", "foo-1", "foo-2"})
                .WithParallel(true)
                .Build()
        };
    }

    private static List<IDefineMachineAddCommandRequest> BuildDefineMachineAddCommandRequestsList(string? tempDir)
    {
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge = UnitTest!.ServiceProvider!
            .GetRequiredService<IDefaultGatewayGetterAction>()
            .GetDefaultGateway();

        return new List<IDefineMachineAddCommandRequest> {
            UnitTest.ServiceProvider!.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IDefineMachineAddCommandRequestBuilder>()
                .UsingDefinition(UnitTest.ServiceProvider!.GetRequiredService<MachineDefinitionBuilderFactory>()
                    .Factory()
                    .BaseBuilder
                    .With3DEnabled(true)
                    .WithBiosLogoImage("")
                    .WithFiles(new Dictionary<string, FileCopyDefinition>())
                    .WithGui(false)
                    .WithOsType(OsTypeEnum.Debian_64)
                    .WithOsVersion("10.9.1")
                    .WithPageFusion(false)
                    .WithProvider(ProviderEnum.Virtualbox)
                    .WithProvisioning(new Dictionary<string, ProvisioningDefinition>())
                    .WithSharedFolders(new Dictionary<string, SharedFolderDefinition>())
                    .WithVideoRamInMb(16)
                    .WithRamInMb(256)
                    .WithVirtualCpus(2)
                    .Parent<MachineDefinitionBuilder>()
                    .WithMachineType("foo")
                    .WithName("foo")
                    .WithInstances(4)
                    .WithIPv4Start(2)
                    .WithIPv4Pattern("10.100.1.#INSTANCE#")
                    .IsPrimary(true)
                    .Enabled(true)
                    .WithVirtualCpUs(2)
                    .WithRamInMb(512)
                    .WithNetworkBridge(defaultSystemNetworkBridge.First().Item1.Description)
                    .Build()
                )
                .Build(),
            UnitTest!.ServiceProvider!.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<IDefineMachineAddCommandRequestBuilder>()
                .UsingDefinition(UnitTest.ServiceProvider!.GetRequiredService<MachineDefinitionBuilderFactory>()
                    .Factory()
                    .BaseBuilder
                    .With3DEnabled(true)
                    .WithBiosLogoImage("")
                    .WithBox(BoxTest)
                    .WithBoxVersion(BoxVersionTest)
                    .WithFiles(new Dictionary<string, FileCopyDefinition>())
                    .WithGui(false)
                    .WithOsType(OsTypeEnum.Debian_64)
                    .WithOsVersion("10.9.1")
                    .WithPageFusion(false)
                    .WithProvider(ProviderEnum.Virtualbox)
                    .WithProvisioning(new Dictionary<string, ProvisioningDefinition>())
                    .WithRamInMb(512)
                    .WithSharedFolders(new Dictionary<string, SharedFolderDefinition>())
                    .WithVideoRamInMb(16)
                    .WithVirtualCpus(2)
                    .Parent<MachineDefinitionBuilder>()
                    .WithMachineType("bar")
                    .WithName("bar")
                    .WithInstances(4)
                    .WithIPv4Start(2)
                    .WithIPv4Pattern("10.100.2.#INSTANCE#")
                    .IsPrimary(false)
                    .Enabled(true)
                    .WithNetworkBridge(defaultSystemNetworkBridge.First().Item1.Description)
                    .Build()
                )
                .Build()
        };
    }

    private static List<IDefineMachineTypeAddCommandRequest> BuildDefineMachineTypeAddCommandRequestsList(
        string? tempDir
    )
    {
        List<IDefineMachineTypeAddCommandRequest> list = new();

        IDefineMachineTypeAddCommandRequest BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
            string typeName,
            string boxName,
            string boxVersion
        )
        {
            return UnitTest!.ServiceProvider!.GetRequiredService<IDefineMachineTypeAddCommandRequestBuilderFactory>()
                .Factory()
                .BaseBuilder.UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs((int) TimeSpan.FromMinutes(2).TotalMilliseconds)
                .Parent<IDefineMachineTypeAddCommandRequestBuilder>()
                .UsingDefinition(UnitTest.ServiceProvider!.GetRequiredService<IMachineTypeDefinitionBuilderFactory>()
                    .Factory()
                    .BaseBuilder.With3DEnabled(true)
                    .WithBiosLogoImage("")
                    .WithBox(boxName)
                    .WithBoxVersion(boxVersion)
                    .WithFiles(new Dictionary<string, FileCopyDefinition>())
                    .WithGui(false)
                    .WithOsType(OsTypeEnum.Debian_64)
                    .WithOsVersion("10.5.0")
                    .WithPageFusion(false)
                    .WithRamInMb(256)
                    .WithVideoRamInMb(16)
                    .WithVirtualCpus(4)
                    .WithFiles(new Dictionary<string, FileCopyDefinition>())
                    .WithProvisioning(new Dictionary<string, ProvisioningDefinition>())
                    .WithSharedFolders(new Dictionary<string, SharedFolderDefinition>())
                    .Parent<IMachineTypeDefinitionBuilder>()
                    .WithName(typeName)
                    .Build())
                .Build();
        }

        list.Add(BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion("foo",
            BoxTest,
            BoxVersionTest));

        list.Add(BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion("bar",
            BoxTest,
            BoxVersionTest));

        return list;
    }

    private static IInitCommandRequest BuildInitCommandRequest(string tempDir)
    {
        return UnitTest!.ServiceProvider!.GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingWorkingDirectory(tempDir)
            .UsingTimeoutMs((int) TimeSpan.FromSeconds(20).TotalMilliseconds)
            .Parent<IInitCommandRequestBuilder>()
            .WithGivenLeadingZeroes(2)
            .Build();
    }


    private static object BuildNameCommandRequestsList(string? tempDir)
    {
        return new List<INameCommandRequest> {
            UnitTest!.ServiceProvider!.GetRequiredService<INameCommandRequestBuilderFactory>().Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs(1000 * 100)
                .Parent<INameCommandRequestBuilder>()
                .WithNames(new[] {"foo-0", "bar-[2-*]"})
                .Build()
        };
    }

    public class ExecutionContext: WithWorkingDirectoryExecutionContext
    {
        public Task<IInitCommandResponse>? InitCommandResponse { get; set; }
    }
}