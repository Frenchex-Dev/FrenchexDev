using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

public class Builder
{
    private const string BoxTest = "generic/alpine316";
    private const string BoxVersionTest = "4.1.10";

    public Func<string, IServiceProvider, IInitCommandRequest> BuildInitCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider serviceProvider) => serviceProvider
            .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeout("20s")
            .Parent<IInitCommandRequestBuilder>()
            .WithGivenLeadingZeroes(2)
            .Build();

    public Func<string, IServiceProvider, List<IDefineMachineTypeAddCommandRequest>>
        BuildDefineMachineTypeAddCommandRequestsListBuilder => (
        string workingDirectory,
        IServiceProvider serviceProvider
    ) =>
    {
        List<IDefineMachineTypeAddCommandRequest> list = new() {
            BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
                workingDirectory,
                "foo",
                BoxTest,
                BoxVersionTest,
                serviceProvider),
            BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
                workingDirectory,
                "bar",
                BoxTest,
                BoxVersionTest,
                serviceProvider)
        };

        return list;
    };

    public Func<string, IServiceProvider, List<IDefineMachineAddCommandRequest>>
        BuildDefineMachineAddCommandRequestsListBuilder => (
        string workingDirectory,
        IServiceProvider serviceProvider
    ) =>
    {
        List<(NetworkInterface n, List<IPAddress?>?)> defaultSystemNetworkBridge = serviceProvider
            .GetRequiredService<IDefaultGatewayGetterAction>()
            .GetDefaultGateway();

        List<IDefineMachineAddCommandRequest> list = new List<IDefineMachineAddCommandRequest>();

        List<DefineMachineAddCommandRequestPayload> payloads = new List<DefineMachineAddCommandRequestPayload> {
            new("foo", "10.100.2.#INSTANCE#", true),
            new("bar", "10.100.3.#INSTANCE#", false)
        };

        foreach (var payload in payloads)
        {
            var def = BuildDefineMachineAddCommandRequest(
                workingDirectory,
                "20s",
                true,
                "",
                new Dictionary<string, FileCopyDefinition>(),
                false,
                OsTypeEnum.Debian_64,
                "10.9.0",
                false,
                ProviderEnum.Virtualbox,
                new Dictionary<string, ProvisioningDefinition> {
                    {
                        "docker.install", new ProvisioningDefinition {
                            Env = new Dictionary<string, string> {
                                {"DOCKER_VERSION", "20.9"}
                            }
                        }
                    }
                },
                new Dictionary<string, SharedFolderDefinition>(),
                16,
                128,
                2,
                "foo",
                payload.Name,
                4,
                2,
                payload.Ipv4Pattern,
                payload.IsPrimary,
                true,
                defaultSystemNetworkBridge,
                serviceProvider.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>(),
                serviceProvider.GetRequiredService<MachineDefinitionBuilderFactory>());

            list.Add(def);
        }

        return list;
    };

    public Func<string, IServiceProvider, List<NameCommandRequestPayload>> BuildNameCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<INameCommandRequestBuilderFactory>();
            List<NameCommandRequestPayload> list = new List<NameCommandRequestPayload>();

            var nameCommandRequest = factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("20s")
                .Parent<INameCommandRequestBuilder>()
                .WithNames(new[] {"foo-0", "bar-[2-*]"})
                .Build();

            var payload = new NameCommandRequestPayload(nameCommandRequest) {
                ExpectedNames = new List<string> {"foo-00", "bar-02"}
            };

            list.Add(payload);

            return list;
        };

    public Func<string, IServiceProvider, List<IStatusCommandRequest>> BuildStatusBeforeUpCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<IStatusCommandRequest> {
                serviceProvider.GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IUpCommandRequest>> BuildUpCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<IUpCommandRequestBuilderFactory>();

            return new List<IUpCommandRequest> {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IUpCommandRequestBuilder>()
                    .UsingNames(new[] {"foo-0", "foo-1"})
                    .WithParallel(true)
                    .WithProvision(false)
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IUpCommandRequestBuilder>()
                    .UsingNames(new[] {"foo-2"})
                    .WithParallel(true)
                    .WithProvision(false)
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IStatusCommandRequest>> BuildStatusAfterUpCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<IStatusCommandRequestBuilderFactory>();

            return new List<IStatusCommandRequest> {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(new[] {"foo-0", "foo-1"})
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(new[] {"bar-1"})
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(new[] {"bar-0"})
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(new[] {"bar-[0-*]", "foo-[0-*]"})
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<ISshConfigCommandRequest>> BuildSshConfigCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<ISshConfigCommandRequestBuilderFactory>();

            return new List<ISshConfigCommandRequest> {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshConfigCommandRequestBuilder>()
                    .UsingNamesOrIds(new[] {
                        "foo-0"
                    })
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshConfigCommandRequestBuilder>()
                    .UsingNamesOrIds(new[] {
                        "bar-1"
                    })
                    .Build()
            };
        };

    public Func<string?, IServiceProvider, List<ISshCommandRequest>> BuildSshCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<ISshCommandRequest> {
                serviceProvider.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshCommandRequestBuilder>()
                    .UsingNames(new[] {"foo-1"})
                    .UsingCommands(new[] {"echo foo"})
                    .Build(),
                serviceProvider.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshCommandRequestBuilder>()
                    .UsingNames(new[] {"bar-0"})
                    .UsingCommands(new[] {"echo bar"})
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IHaltCommandRequest>> BuildHaltCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<IHaltCommandRequestBuilderFactory>();

            return new List<IHaltCommandRequest> {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IHaltCommandRequestBuilder>()
                    .UsingNames(new[] {"foo-0", "foo-1"})
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IHaltCommandRequestBuilder>()
                    .UsingNames(new[] {"bar-0"})
                    .Build(),
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IHaltCommandRequestBuilder>()
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IDestroyCommandRequest>> BuildDestroyCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<IDestroyCommandRequest> {
                serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IDestroyCommandRequestBuilder>()
                    .WithForce(true)
                    .UsingName("foo-0")
                    .Build(),
                serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IDestroyCommandRequestBuilder>()
                    .WithForce(true)
                    .UsingName("foo-1")
                    .Build(),
                serviceProvider.GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IDestroyCommandRequestBuilder>()
                    .WithForce(true)
                    .Build()
            };
        };

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
            .UsingTimeout("2m")
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

    private static IDefineMachineAddCommandRequest BuildDefineMachineAddCommandRequest(
        string? workingDirectory,
        string timeoutStr,
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
        IDefineMachineAddCommandRequestBuilderFactory defineMachineAddCommandRequestBuilderFactory,
        MachineDefinitionBuilderFactory machineDefinitionBuilderFactory
    )
    {
        return defineMachineAddCommandRequestBuilderFactory
            .Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeout(timeoutStr)
            .Parent<IDefineMachineAddCommandRequestBuilder>()
            .UsingDefinition(machineDefinitionBuilderFactory
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


    private class DefineMachineAddCommandRequestPayload
    {
        public DefineMachineAddCommandRequestPayload(string name, string ipv4Pattern, bool isPrimary)
        {
            Name = name;
            Ipv4Pattern = ipv4Pattern;
            IsPrimary = isPrimary;
        }

        public string Name { get; }
        public string Ipv4Pattern { get; }
        public bool IsPrimary { get; }
    }
}