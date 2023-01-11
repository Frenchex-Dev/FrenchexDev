#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows.WorkflowData;

public interface IWorkflowDataBuilder<T>
{
    T Build(string workingDirectory, IServiceProvider serviceProvider);
}

public interface IVagrantLibWorkflowDataBuilder : IWorkflowDataBuilder<PayloadBuilderPayload>
{
}

public class VagrantLibWorkflowDataBuilderData1 : IVagrantLibWorkflowDataBuilder
{
    public PayloadBuilderPayload Build(string workingDirectory, IServiceProvider serviceProvider)
    {
        var baseRequest = new BaseCommandRequest(
            workingDirectory,
            false,
            false,
            false,
            false,
            false,
            false,
            true,
            false,
            null,
            "vagrant"
        );

        return new PayloadBuilderPayload
        {
            InitCommandRequestBuilderPayload = new InitCommandRequestBuilderPayload
            {
                Request = new InitCommandRequest(
                    "4.1.10",
                    false,
                    true,
                    null,
                    null,
                    "generic/alpine38",
                    null,
                    baseRequest
                ),
                Timeout = "2s",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            UpCommandRequestBuilderPayload = new UpCommandRequestBuilderPayload
            {
                Request = new UpCommandRequest(
                    Array.Empty<string>(),
                    false,
                    Array.Empty<string>(),
                    false,
                    false,
                    "virtualbox",
                    false,
                    false,
                    baseRequest
                ),
                Timeout = "4m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            ProvisionCommandRequestBuilderPayload = new ProvisionCommandRequestBuilderPayload
            {
                Request = new ProvisionCommandRequest(baseRequest, null, new[] { "docker.install" }),
                Timeout = "10m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            StatusCommandRequestBuilderPayload = new StatusCommandRequestBuilderPayload
            {
                Request = new StatusCommandRequest(baseRequest, Array.Empty<string>()),
                Timeout = "1m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            SshConfigCommandRequestBuilderPayload = new SshConfigCommandRequestBuilderPayload
            {
                Request = new SshConfigCommandRequest(string.Empty, string.Empty, baseRequest),
                Timeout = "1m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            SshCommandRequestBuilderPayload = new SshCommandRequestBuilderPayload
            {
                Request = new SshCommandRequest(
                    string.Empty,
                    "echo hello",
                    true,
                    string.Empty,
                    false,
                    baseRequest
                ),
                Timeout = "1m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            HaltCommandRequestBuilderPayload = new HaltCommandRequestBuilderPayload
            {
                Request = new HaltCommandRequest(Array.Empty<string>(), false, baseRequest, "2m"),
                Timeout = "3m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            },
            DestroyCommandRequestBuilderPayload = new DestroyCommandRequestBuilderPayload
            {
                Request = new DestroyCommandRequest(
                    string.Empty,
                    true,
                    true,
                    false,
                    100,
                    baseRequest
                ),
                Timeout = "3m",
                WorkingDirectory = workingDirectory,
                ServiceProvider = serviceProvider
            }
        };
    }
}