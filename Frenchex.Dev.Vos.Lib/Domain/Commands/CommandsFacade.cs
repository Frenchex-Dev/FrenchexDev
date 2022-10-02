using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Machine.Add.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.MachineType.Add.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Define.Provisioning.Map.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Destroy.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Halt.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.SshConfig.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Facade;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Up.Facade;

namespace Frenchex.Dev.Vos.Lib.Domain.Commands;

public class CommandsFacade : ICommandsFacade
{
    public CommandsFacade(
        IDefineMachineTypeAddCommandFacade defineMachineTypeAddCommandFacade,
        IDefineMachineAddCommandFacade defineMachineAddCommandFacade,
        IDefineProvisioningMapCommandFacade defineProvisioningMapCommandFacade,
        IDestroyCommandFacade destroyCommandFacade,
        IHaltCommandFacade haltCommandFacade,
        IInitCommandFacade initCommandFacade,
        INameCommandFacade nameCommandFacade,
        ISshCommandFacade sshCommandFacade,
        ISshConfigCommandFacade sshConfigCommandFacade,
        IStatusCommandFacade statusCommandFacade,
        IUpCommandFacade upCommandFacade
    )
    {
        DefineMachineTypeAddCommandFacade = defineMachineTypeAddCommandFacade;
        DefineMachineAddCommandFacade = defineMachineAddCommandFacade;
        DefineProvisioningMapCommandFacade = defineProvisioningMapCommandFacade;
        DestroyCommandFacade = destroyCommandFacade;
        HaltCommandFacade = haltCommandFacade;
        InitCommandFacade = initCommandFacade;
        NameCommandFacade = nameCommandFacade;
        SshCommandFacade = sshCommandFacade;
        SshConfigCommandFacade = sshConfigCommandFacade;
        StatusCommandFacade = statusCommandFacade;
        UpCommandFacade = upCommandFacade;
    }

    public IDefineMachineTypeAddCommandFacade DefineMachineTypeAddCommandFacade { get; }
    public IDefineMachineAddCommandFacade DefineMachineAddCommandFacade { get; }
    public IDefineProvisioningMapCommandFacade DefineProvisioningMapCommandFacade { get; }
    public IDestroyCommandFacade DestroyCommandFacade { get; }
    public IHaltCommandFacade HaltCommandFacade { get; }
    public IInitCommandFacade InitCommandFacade { get; }
    public INameCommandFacade NameCommandFacade { get; }
    public ISshCommandFacade SshCommandFacade { get; }
    public ISshConfigCommandFacade SshConfigCommandFacade { get; }
    public IStatusCommandFacade StatusCommandFacade { get; }
    public IUpCommandFacade UpCommandFacade { get; }
}