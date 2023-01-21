#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Destroy.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Halt.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Provision.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.SshConfig.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Status.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Up.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Tests.Domain.Workflows;

public class PayloadBuilderPayload
{
    public InitCommandRequestBuilderPayload? InitCommandRequestBuilderPayload { get; init; }
    public UpCommandRequestBuilderPayload? UpCommandRequestBuilderPayload { get; init; }
    public ProvisionCommandRequestBuilderPayload? ProvisionCommandRequestBuilderPayload { get; init; }
    public StatusCommandRequestBuilderPayload? StatusCommandRequestBuilderPayload { get; init; }
    public SshConfigCommandRequestBuilderPayload? SshConfigCommandRequestBuilderPayload { get; init; }
    public SshCommandRequestBuilderPayload? SshCommandRequestBuilderPayload { get; init; }
    public HaltCommandRequestBuilderPayload? HaltCommandRequestBuilderPayload { get; init; }
    public DestroyCommandRequestBuilderPayload? DestroyCommandRequestBuilderPayload { get; init; }
}

public abstract class ACommandRequestBuilderPayload
{
    public string? Timeout { get; init; }
    public string? WorkingDirectory { get; init; }
    public IServiceProvider? ServiceProvider { get; init; }

    public IServiceProvider GetServiceProvider()
    {
        return ServiceProvider!;
    }
}

public abstract class AGenericCommandRequestBuilderPayload<T> : ACommandRequestBuilderPayload where T : class
{
    public T? Request { get; init; }

    public T GetRequest()
    {
        return Request!;
    }
}

public interface ICommandRequest<T>
{
    T? Request { get; init; }
}

public class UpCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<UpCommandRequest>,
    ICommandRequest<UpCommandRequest>
{
}

public class InitCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<InitCommandRequest>,
    ICommandRequest<InitCommandRequest>
{
}

public class ProvisionCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<ProvisionCommandRequest>,
    ICommandRequest<ProvisionCommandRequest>
{
}

public class StatusCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<StatusCommandRequest>,
    ICommandRequest<StatusCommandRequest>
{
}

public class SshConfigCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<SshConfigCommandRequest>,
    ICommandRequest<SshConfigCommandRequest>
{
}

public class SshCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<SshCommandRequest>,
    ICommandRequest<SshCommandRequest>
{
}

public class HaltCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<HaltCommandRequest>,
    ICommandRequest<HaltCommandRequest>
{
}

public class DestroyCommandRequestBuilderPayload : AGenericCommandRequestBuilderPayload<DestroyCommandRequest>,
    ICommandRequest<DestroyCommandRequest>
{
}