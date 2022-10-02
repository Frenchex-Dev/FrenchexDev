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

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands;

public interface ICommandsFacade
{
    IDefineMachineTypeAddCommandFacade  DefineMachineTypeAddCommandFacade { get; }
    IDefineMachineAddCommandFacade DefineMachineAddCommandFacade { get; }
    IDefineProvisioningMapCommandFacade DefineProvisioningMapCommandFacade { get; }
    IDestroyCommandFacade DestroyCommandFacade { get; }
    IHaltCommandFacade HaltCommandFacade { get; }
    IInitCommandFacade InitCommandFacade { get; }
    INameCommandFacade NameCommandFacade { get; }
    ISshCommandFacade SshCommandFacade { get; }
    ISshConfigCommandFacade SshConfigCommandFacade { get; }
    IStatusCommandFacade StatusCommandFacade { get; }
    IUpCommandFacade UpCommandFacade { get; }
}