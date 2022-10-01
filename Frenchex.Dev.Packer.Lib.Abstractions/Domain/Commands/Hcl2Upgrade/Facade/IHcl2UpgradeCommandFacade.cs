using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Facade;

public interface IHcl2UpgradeCommandFacade : IFacableCommand,
    IFacade<IHcl2UpgradeCommand, IHcl2UpgradeCommandRequestBuilderFactory, IHcl2UpgradeCommandRequestBuilder>
{
}