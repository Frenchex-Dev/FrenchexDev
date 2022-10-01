using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.Machine.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Define.MachineType.Add;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Destroy;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Halt;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Init;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh;
using Frenchex.Dev.Vos.Lib.Domain.Commands.SshConfig;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Status;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Up;

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.Commands;

public class Builder
{
    public Func<string, IServiceProvider, IInitCommandRequest>? BuildInitCommandRequestBuilder { get; set; }

    public Func<string, IServiceProvider, List<IDefineMachineTypeAddCommandRequest>>?
        BuildDefineMachineTypeAddCommandRequestsListBuilder { get; set; }

    public Func<string, IServiceProvider, List<IDefineMachineAddCommandRequest>>?
        BuildDefineMachineAddCommandRequestsListBuilder { get; set; }

    public Func<string, IServiceProvider, List<NameCommandRequestPayload>>? BuildNameCommandRequestsListBuilder
    {
        get;
        set;
    }

    public Func<string, IServiceProvider, List<IStatusCommandRequest>>? BuildStatusBeforeUpCommandRequestsListBuilder
    {
        get;
        set;
    }

    public Func<string, IServiceProvider, List<IUpCommandRequest>>? BuildUpCommandRequestsListBuilder { get; set; }

    public Func<string, IServiceProvider, List<IStatusCommandRequest>>? BuildStatusAfterUpCommandRequestsListBuilder
    {
        get;
        set;
    }

    public Func<string, IServiceProvider, List<ISshConfigCommandRequest>>? BuildSshConfigCommandRequestsListBuilder
    {
        get;
        set;
    }

    public Func<string?, IServiceProvider, List<ISshCommandRequest>>? BuildSshCommandRequestsListBuilder { get; set; }
    public Func<string, IServiceProvider, List<IHaltCommandRequest>>? BuildHaltCommandRequestsListBuilder { get; set; }

    public Func<string, IServiceProvider, List<IDestroyCommandRequest>>? BuildDestroyCommandRequestsListBuilder
    {
        get;
        set;
    }
}