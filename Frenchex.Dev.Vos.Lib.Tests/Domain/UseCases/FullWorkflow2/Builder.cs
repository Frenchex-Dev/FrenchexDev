#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Net;
using System.Net.NetworkInformation;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Networking;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.UseCases.FullWorkflow2;

public class Builder
{
    private const string BoxTest = "roboxes/alpine317";
    private const string BoxVersionTest = "4.2.8";

    public Func<string, IServiceProvider, IInitCommandRequest> BuildInitCommandRequestBuilder =>
        (workingDirectory, serviceProvider) => serviceProvider
            .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeout("20s")
            .Parent<IInitCommandRequestBuilder>()
            .WithGivenLeadingZeroes(2)
            .Build();

    public Func<string, IServiceProvider, List<IDefineMachineTypeAddCommandRequest>>
        BuildDefineMachineTypeAddCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var list = new List<IDefineMachineTypeAddCommandRequest>
            {
                BuildDefineMachineTypeAddCommandRequestWithSpecifiedBoxNameAndVersion(
                    workingDirectory,
                    "foo",
                    BoxTest,
                    BoxVersionTest,
                    serviceProvider)
            };

            return list;
        };

    public Func<string, IServiceProvider, List<IDefineMachineAddCommandRequest>>
        BuildDefineMachineAddCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var defaultSystemNetworkBridge = serviceProvider
                .GetRequiredService<IDefaultGatewayResolverAction>()
                .ResolveDefaultGateway();

            var payloads = new List<DefineMachineAddCommandRequestPayload>
            {
                new("foo", "foo", "10.100.2.#INSTANCE#", true)
            };

            return payloads.Select(payload => BuildDefineMachineAddCommandRequest(
                workingDirectory,
                "20s",
                256,
                4,
                payload.MachineTypeName,
                payload.Name,
                1,
                2,
                payload.Ipv4Pattern,
                payload.IsPrimary,
                true,
                defaultSystemNetworkBridge,
                serviceProvider.GetRequiredService<IDefineMachineAddCommandRequestBuilderFactory>(),
                serviceProvider.GetRequiredService<MachineDefinitionBuilderFactory>()
            )).ToList();
        };

    public Func<string, IServiceProvider, List<NameCommandRequestPayload>> BuildNameCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<INameCommandRequestBuilderFactory>();
            var list = new List<NameCommandRequestPayload>();

            INameCommandRequest? nameCommandRequest = factory.Factory()
                .BaseBuilder
                .UsingWorkingDirectory(workingDirectory)
                .UsingTimeout("20s")
                .Parent<INameCommandRequestBuilder>()
                .WithNames(new[] { "foo-0" })
                .Build();

            var payload = new NameCommandRequestPayload(nameCommandRequest)
            {
                ExpectedNames = new List<string> { "foo-00" }
            };

            list.Add(payload);

            return list;
        };

    public Func<string, IServiceProvider, List<IStatusCommandRequest>> BuildStatusBeforeUpCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<IStatusCommandRequest>
            {
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

            return new List<IUpCommandRequest>
            {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IUpCommandRequestBuilder>()
                    .UsingNames(new[] { "foo-0" })
                    .WithParallel(true)
                    .WithProvision(false)
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IStatusCommandRequest>> BuildStatusAfterUpCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<IStatusCommandRequestBuilderFactory>();

            return new List<IStatusCommandRequest>
            {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IStatusCommandRequestBuilder>()
                    .WithNames(new[] { "foo-0" })
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<ISshConfigCommandRequest>> BuildSshConfigCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<ISshConfigCommandRequestBuilderFactory>();

            return new List<ISshConfigCommandRequest>
            {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshConfigCommandRequestBuilder>()
                    .UsingNamesOrIds(new[]
                    {
                        "foo-0"
                    })
                    .Build()
            };
        };

    public Func<string?, IServiceProvider, List<ISshCommandRequest>> BuildSshCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<ISshCommandRequest>
            {
                serviceProvider.GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<ISshCommandRequestBuilder>()
                    .UsingNames(new[] { "foo-0" })
                    .UsingCommands(new[] { "echo foo" })
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IHaltCommandRequest>> BuildHaltCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            var factory = serviceProvider.GetRequiredService<IHaltCommandRequestBuilderFactory>();

            return new List<IHaltCommandRequest>
            {
                factory.Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IHaltCommandRequestBuilder>()
                    .UsingNames(new[] { "foo-0" })
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IDestroyCommandRequest>> BuildDestroyCommandRequestsListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<IDestroyCommandRequest>
            {
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
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IDefineProvisioningMapCommandRequest>>
        BuildDefineProvisioningMapCommandRequestListBuilder =>
        (workingDirectory, serviceProvider) =>
        {
            return new List<IDefineProvisioningMapCommandRequest>
            {
                serviceProvider.GetRequiredService<IDefineProvisioningMapCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("1m")
                    .Parent<IDefineProvisioningMapCommandRequestBuilder>()
                    .UsingNames(new[] { "foo-0" })
                    .UsingProvisioning("docker-ce/install")
                    .Privileged(true)
                    .Version("v1")
                    .Enabled(true)
                    .Build()
            };
        };

    public Func<string, IServiceProvider, List<IProvisionCommandRequest>> BuildProvisionCommandRequestsListBuilder =>
        (workingDirectory, provider) =>
        {
            return new List<IProvisionCommandRequest>
            {
                provider.GetRequiredService<IProvisionCommandRequestBuilderFactory>().Factory()
                    .BaseBuilder
                    .UsingWorkingDirectory(workingDirectory)
                    .UsingTimeout("10m")
                    .Parent<IProvisionCommandRequestBuilder>()
                    .UsingNames(new[] { "foo-0" })
                    .UsingProvisionWith(new[] { "docker-ce/install" })
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
                .WithBox(boxName)
                .WithBoxVersion(boxVersion)
                .WithOsVersion("v1")
                .WithVirtualCpus(6)
                .Enabled(true)
                .Parent<IMachineTypeDefinitionBuilder>()
                .WithName(typeName)
                .Build())
            .Build();
    }

    private static IDefineMachineAddCommandRequest BuildDefineMachineAddCommandRequest(
        string? workingDirectory,
        string timeBox,
        int ramInMb,
        int vCpus,
        string machineTypeDefinitionName,
        string name,
        int instances,
        int ipv4Start,
        string ipv4Pattern,
        bool isPrimary,
        bool enabled,
        List<(NetworkInterface NetworkInterface, List<IPAddress?>?)> defaultSystemNetworkBridge,
        IDefineMachineAddCommandRequestBuilderFactory defineMachineAddCommandRequestBuilderFactory,
        MachineDefinitionBuilderFactory machineDefinitionBuilderFactory
    )
    {
        return defineMachineAddCommandRequestBuilderFactory
            .Factory()
            .BaseBuilder
            .UsingWorkingDirectory(workingDirectory)
            .UsingTimeout(timeBox)
            .Parent<IDefineMachineAddCommandRequestBuilder>()
            .UsingDefinition(machineDefinitionBuilderFactory
                .Factory()
                .WithMachineType(machineTypeDefinitionName)
                .WithName(name)
                .WithInstances(instances)
                .WithIPv4Start(ipv4Start)
                .WithIPv4Pattern(ipv4Pattern)
                .IsPrimary(isPrimary)
                .Enabled(enabled)
                .WithVirtualCpUs(vCpus)
                .WithRamInMb(ramInMb)
                .WithNetworkBridge(defaultSystemNetworkBridge.First().NetworkInterface.Description)
                .Build()
            )
            .Build();
    }


    private class DefineMachineAddCommandRequestPayload
    {
        public DefineMachineAddCommandRequestPayload(string name, string machineTypeName, string ipv4Pattern,
            bool isPrimary)
        {
            Name = name;
            MachineTypeName = machineTypeName;
            Ipv4Pattern = ipv4Pattern;
            IsPrimary = isPrimary;
        }

        public string Name { get; }
        public string MachineTypeName { get; }
        public string Ipv4Pattern { get; }
        public bool IsPrimary { get; }
    }
}