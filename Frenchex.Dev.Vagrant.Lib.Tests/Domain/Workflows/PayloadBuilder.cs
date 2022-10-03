using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Up.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

public class PayloadBuilder
{
    public Func<string, IServiceProvider, IInitCommandRequest> InitCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<IInitCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("1m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<IInitCommandRequestBuilder>()
            .UsingBoxName("generic/alpine38")
            .UsingBoxVersion("4.1.10")
            .Build();

    public Func<string, IServiceProvider, IUpCommandRequest> UpCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<IUpCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("10m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<IUpCommandRequestBuilder>()
            .WithProvision(false)
            .Build();

    public Func<string, IServiceProvider, IProvisionCommandRequest> ProvisionCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) =>
        {
            var factory =
                sp.GetRequiredService<IProvisionCommandRequestBuilderFactory>();

            var builder = factory.Factory();

            builder
                .BaseBuilder
                .UsingTimeout("1m")
                .UsingWorkingDirectory(workingDirectory)
                .Parent<IProvisionCommandRequestBuilder>()
                .ProvisionWith(new[] {"docker.install"})
                ;

            return builder.Build();
        };

    public Func<string, IServiceProvider, IStatusCommandRequest> StatusCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<IStatusCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("1m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<IStatusCommandRequestBuilder>()
            .Build();

    public Func<string, IServiceProvider, ISshConfigCommandRequest> SshConfigCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<ISshConfigCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("1m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<ISshConfigCommandRequestBuilder>()
            .UsingName("default")
            .Build();

    public Func<string, IServiceProvider, ISshCommandRequest> SshCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<ISshCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("1m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<ISshCommandRequestBuilder>()
            .UsingCommand("echo foo")
            .UsingNameOrId("default")
            .Build();

    public Func<string, IServiceProvider, IHaltCommandRequest> HaltCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<IHaltCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("3m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<IHaltCommandRequestBuilder>()
            .Build();

    public Func<string, IServiceProvider, IDestroyCommandRequest> DestroyCommandRequestBuilder =>
        (string workingDirectory, IServiceProvider sp) => sp
            .GetRequiredService<IDestroyCommandRequestBuilderFactory>().Factory()
            .BaseBuilder
            .UsingTimeout("3m")
            .UsingWorkingDirectory(workingDirectory)
            .Parent<IDestroyCommandRequestBuilder>()
            .WithForce(true)
            .Build();
    
}