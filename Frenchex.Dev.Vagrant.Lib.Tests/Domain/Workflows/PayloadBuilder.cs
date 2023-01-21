#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

public class PayloadBuilder
{
    public Func<InitCommandRequestBuilderPayload, IInitCommandRequest> InitCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<IInitCommandRequestBuilder>()
            .UsingBoxName(payload.GetRequest().BoxName!)
            .UsingBoxVersion(payload.GetRequest().BoxVersion!)
            .Build();

    public Func<UpCommandRequestBuilderPayload, IUpCommandRequest> UpCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<IUpCommandRequestBuilder>()
            .WithProvision(payload.GetRequest().Provision)
            .UsingProvisionWith(payload.GetRequest().ProvisionWith)
            .WithParallel(payload.GetRequest().Parallel)
            .WithInstallProvider(payload.GetRequest().InstallProvider)
            .UsingNamesOrIds(payload.GetRequest().NamesOrIds)
            .Build();

    public Func<ProvisionCommandRequestBuilderPayload, IProvisionCommandRequest> ProvisionCommandRequestBuilder =>
        payload =>
        {
            var factory =
                payload.GetServiceProvider().GetRequiredService<IProvisionCommandRequestBuilderFactory>();

            IProvisionCommandRequestBuilder? builder = factory.Factory();

            builder
                .BaseBuilder
                .UsingTimeout(payload.Timeout)
                .UsingWorkingDirectory(payload.WorkingDirectory)
                .Parent<IProvisionCommandRequestBuilder>()
                .ProvisionWith(payload.GetRequest().ProvisionWith!)
                .ProvisionVmName(payload.GetRequest().VmName!)
                ;

            return builder.Build();
        };

    public Func<StatusCommandRequestBuilderPayload, IStatusCommandRequest> StatusCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<IStatusCommandRequestBuilder>()
            .WithNamesOrIds(payload.GetRequest().NamesOrIds)
            .Build();

    public Func<SshConfigCommandRequestBuilderPayload, ISshConfigCommandRequest> SshConfigCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<ISshConfigCommandRequestBuilder>()
            .UsingName(payload.GetRequest().NameOrId)
            .UsingHost(payload.GetRequest().Host)
            .Build();

    public Func<SshCommandRequestBuilderPayload, ISshCommandRequest> SshCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<ISshCommandRequestBuilder>()
            .UsingCommand(payload.GetRequest().Command)
            .UsingNameOrId(payload.GetRequest().NameOrId)
            .Build();

    public Func<HaltCommandRequestBuilderPayload, IHaltCommandRequest> HaltCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<IHaltCommandRequestBuilder>()
            .WithForce(payload.GetRequest().Force)
            .UsingHaltTimeout(payload.GetRequest().HaltTimeout)
            .UsingNamesOrIds(payload.GetRequest().NamesOrIds)
            .Build();

    public Func<DestroyCommandRequestBuilderPayload, IDestroyCommandRequest> DestroyCommandRequestBuilder =>
        payload => payload.GetServiceProvider()
            .GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout(payload.Timeout)
            .UsingWorkingDirectory(payload.WorkingDirectory)
            .Parent<IDestroyCommandRequestBuilder>()
            .WithForce(payload.GetRequest().Force)
            .UsingName(payload.GetRequest().NameOrId)
            .Build();
}