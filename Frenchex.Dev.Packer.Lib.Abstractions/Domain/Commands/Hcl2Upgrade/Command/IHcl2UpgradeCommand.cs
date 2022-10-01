using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Command;

public interface IHcl2UpgradeCommand : IFacableCommand,
    ICommand<IHcl2UpgradeCommandRequest, IHcl2UpgradeCommandResponse>
{
}