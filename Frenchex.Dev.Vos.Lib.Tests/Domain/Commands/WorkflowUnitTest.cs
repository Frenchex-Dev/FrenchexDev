using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Dotnet.Core.UnitTesting.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Domain;
using Frenchex.Dev.Vagrant.Lib.Tests.Abstractions.Domain;
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

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

[TestClass]
public class CompleteWorkflowTests1 : AbstractUnitTest
{
    private const string BoxTest = "generic/alpine316";
    private const string BoxVersionTest = "4.1.10";

    public static IEnumerable<object[]> DataSource()
    {
        UnitTest = VosUnitTestBase.CreateUnitTest<ExecutionContext>();
        UnitTest.BuildIfNecessary();

        var max = 1;
        for (var i = 0; i < max; i++)
        {
            var tempDir = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());

            yield return new[] {
                BuildInitCommandRequest(tempDir, UnitTest.ServiceProvider!),
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
    [TestCategory(TestCategories.NeedVagrant)]
    public async Task VosWortkflowUnitTes(
        IInitCommandRequest initRequest,
        IList<IDefineMachineTypeAddCommandRequest> defineMachineTypeAddCommandRequestsList,
        IList<IDefineMachineAddCommandRequest> defineMachineAddCommandRequestsList,
        IList<NameCommandRequestPayload> nameCommandRequestsList,
        IList<IStatusCommandRequest> statusBeforeUpCommandRequestsList,
        IList<IUpCommandRequest> upRequestsList,
        IList<IStatusCommandRequest> statusAfterUpCommandRequestsList,
        IList<ISshConfigCommandRequest> sshConfigCommandRequestsList,
        IList<ISshCommandRequest> sshCommandRequestsList,
        IList<IHaltCommandRequest> haltRequestsList,
        IList<IDestroyCommandRequest> destroyRequestsLists
    )
    {
        var vsDebuggingContext = new UnitTest.VsCodeDebugging() {TellMe = true, Keep = true};

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
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                var defineMachineTypeAddCommand = provider.GetRequiredService<IDefineMachineTypeAddCommand>();
                foreach (var item in defineMachineTypeAddCommandRequestsList)
                {
                    await defineMachineTypeAddCommand.Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                var defineMachineAddCommand = provider.GetRequiredService<IDefineMachineAddCommand>();
                foreach (var item in defineMachineAddCommandRequestsList)
                {
                    await defineMachineAddCommand.Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext
        );

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                var nameCommand = provider.GetRequiredService<INameCommand>();

                foreach (var item in nameCommandRequestsList)
                {
                    var response = await nameCommand.Execute(item.Request);
                    Assert.IsNotNull(response);
                    if (item.ExpectedNames.Any())
                    {
                        Assert.IsTrue(item.ExpectedNames.All(x => response.Names.Contains(x)));
                    }
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);

        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                var statusCommand = provider.GetRequiredService<IStatusCommand>();
                foreach (var item in statusBeforeUpCommandRequestsList)
                {
                    var statusResponse = await statusCommand.Execute(item);

                    Assert.IsNotNull(statusResponse, "got status response");
                    Assert.IsTrue(statusResponse.Statuses.Any(), "got machines in status response");
                    Assert.IsTrue(statusResponse
                        .Statuses
                        .All(x => x.Value
                            .ToString()
                            .Contains(VagrantMachineStatusEnum.NotCreated.ToString()) == true));
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);

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
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshConfigCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshConfigCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshConfigCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshConfigCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in sshCommandRequestsList)
                {
                    await provider.GetRequiredService<ISshCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);


        await UnitTest!.RunAsync<ExecutionContext>(
            async (provider, configuration, context, vsCode) =>
            {
                foreach (var item in haltRequestsList)
                {
                    await provider.GetRequiredService<IHaltCommand>().Execute(item);
                }
            },
            (provider, root, context) => Task.CompletedTask,
            (provider, root, context) => Task.CompletedTask,
            vsDebuggingContext);


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
            },
            vsDebuggingContext);

        vsDebuggingContext.Stop();

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


    internal class Payload
    {
        public string Name { get; init; }
        public string Ipv4Pattern { get; init; }
        public bool IsPrimary { get; init; }
    }

    private static List<IDefineMachineAddCommandRequest> BuildDefineMachineAddCommandRequestsList(string? tempDir)
    {
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge = UnitTest!.ServiceProvider!
            .GetRequiredService<IDefaultGatewayGetterAction>()
            .GetDefaultGateway();

        var list = new List<IDefineMachineAddCommandRequest>();

        var payloads = new List<Payload>() {
            new() {Name = "foo", Ipv4Pattern = "10.100.2.#INSTANCE#", IsPrimary = true},
            new() {Name = "bar", Ipv4Pattern = "10.100.3.#INSTANCE#", IsPrimary = false}
        };

        foreach (var payload in payloads)
        {
            var def = BuildDefineMachineAddCommandRequest(
                tempDir,
                TimeSpan.FromSeconds(20),
                true,
                "",
                new Dictionary<string, FileCopyDefinition>(),
                false,
                OsTypeEnum.Debian_64,
                "10.9.0",
                false,
                ProviderEnum.Virtualbox,
                new Dictionary<string, ProvisioningDefinition>(),
                new Dictionary<string, SharedFolderDefinition>(),
                16,
                128,
                2,
                "foo",
                payload.Name,
                4,
                2,
                payload.Ipv4Pattern,
                true,
                true,
                defaultSystemNetworkBridge,
                UnitTest.ServiceProvider!.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>());

            list.Add(def);
        }

        return list;
    }

    private static IDefineMachineAddCommandRequest BuildDefineMachineAddCommandRequest(
        string? workingDirectory,
        TimeSpan fromSecondsTs,
        bool enable3d,
        string biosLogoImage,
        Dictionary<string, FileCopyDefinition> withFiles,
        bool withGui,
        OsTypeEnum withOsTypeEnum,
        string withOsVersion,
        bool withPageFusion,
        ProviderEnum withProvider,
        Dictionary<string, ProvisioningDefinition> provisioningDefinitions,
        Dictionary<string, SharedFolderDefinition> sharedFolderDefinitions,
        int videoRamInMb,
        int ramInMb,
        int vCpus,
        string machineTypeDefinitionName,
        string name,
        int instances,
        int ipv4Start,
        string ipv4Pattern,
        bool isPrimary,
        bool enabled,
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge,
        IDefineMachineAddCommandRequestBuilderFactory defineMachineAddCommandRequestBuilderFactory
    )
    {
        return defineMachineAddCommandRequestBuilderFactory
            .Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeoutMs((int) fromSecondsTs.TotalMilliseconds)
            .Parent<IDefineMachineAddCommandRequestBuilder>()
            .UsingDefinition(UnitTest.ServiceProvider!.GetRequiredService<MachineDefinitionBuilderFactory>()
                .Factory()
                .BaseBuilder
                .With3DEnabled(enable3d)
                .WithBiosLogoImage(biosLogoImage)
                .WithFiles(withFiles)
                .WithGui(withGui)
                .WithOsType(withOsTypeEnum)
                .WithOsVersion(withOsVersion)
                .WithPageFusion(withPageFusion)
                .WithProvider(withProvider)
                .WithProvisioning(provisioningDefinitions)
                .WithSharedFolders(sharedFolderDefinitions)
                .WithVideoRamInMb(videoRamInMb)
                .WithRamInMb(ramInMb)
                .WithVirtualCpus(vCpus)
                .Parent<MachineDefinitionBuilder>()
                .WithMachineType(machineTypeDefinitionName)
                .WithName(name)
                .WithInstances(instances)
                .WithIPv4Start(ipv4Start)
                .WithIPv4Pattern(ipv4Pattern)
                .IsPrimary(isPrimary)
                .Enabled(enabled)
                .WithNetworkBridge(defaultSystemNetworkBridge.First().Item1.Description)
                .Build()
            )
            .Build();
    }

    private static IDefineMachineTypeAddCommandRequest
        BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
            string workingDirectory,
            string typeName,
            string boxName,
            string boxVersion,
            IServiceProvider serviceProvider
        )
    {
        return serviceProvider.GetRequiredService<IDefineMachineTypeAddCommandRequestBuilderFactory>()
            .Factory()
            .BaseBuilder.UsingWorkingDirectory(workingDirectory)
            .UsingTimeoutMs((int) TimeSpan.FromMinutes(2).TotalMilliseconds)
            .Parent<IDefineMachineTypeAddCommandRequestBuilder>()
            .UsingDefinition(serviceProvider.GetRequiredService<IMachineTypeDefinitionBuilderFactory>()
                .Factory()
                .BaseBuilder
                .With3DEnabled(true)
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
                .Enabled(true)
                .Parent<IMachineTypeDefinitionBuilder>()
                .WithName(typeName)
                .Build())
            .Build();
    }

    private static List<IDefineMachineTypeAddCommandRequest> BuildDefineMachineTypeAddCommandRequestsList(
        string tempDir
    )
    {
        List<IDefineMachineTypeAddCommandRequest> list = new();

        list.Add(BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
            tempDir,
            "foo",
            BoxTest,
            BoxVersionTest,
            UnitTest.ServiceProvider!));

        list.Add(BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
            tempDir,
            "bar",
            BoxTest,
            BoxVersionTest,
            UnitTest.ServiceProvider!));

        return list;
    }

    private static IInitCommandRequest BuildInitCommandRequest(string tempDir, IServiceProvider serviceProvider)
    {
        return serviceProvider.GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingWorkingDirectory(tempDir)
            .UsingTimeoutMs((int) TimeSpan.FromSeconds(20).TotalMilliseconds)
            .Parent<IInitCommandRequestBuilder>()
            .WithGivenLeadingZeroes(2)
            .Build();
    }


    public class NameCommandRequestPayload
    {
        public INameCommandRequest Request { get; init; }
        public List<string> ExpectedNames { get; set; } = new List<string>();
    }

    private static object BuildNameCommandRequestsList(string? tempDir)
    {
        var factory = UnitTest!.ServiceProvider!.GetRequiredService<INameCommandRequestBuilderFactory>();
        var list = new List<NameCommandRequestPayload>();
      
        var payload = new NameCommandRequestPayload() {
            Request = factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(tempDir)
                .UsingTimeoutMs((int) TimeSpan.FromSeconds(20).TotalMilliseconds)
                .Parent<INameCommandRequestBuilder>()
                .WithNames(new[] {"foo-0", "bar-[2-*]"})
                .Build(),
            ExpectedNames = new List<string>() {"foo-00", "bar-02"}
        };

        list.Add(payload);

        return list;
    }

    public class ExecutionContext : WithWorkingDirectoryExecutionContext
    {
        public Task<IInitCommandResponse>? InitCommandResponse { get; set; }
    }
}