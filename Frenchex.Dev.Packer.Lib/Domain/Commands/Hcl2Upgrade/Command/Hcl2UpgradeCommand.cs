using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Command;

public class Hcl2UpgradeCommand : IHcl2UpgradeCommand
{
    public string GetCliCommandName()
    {
        return "hcl2upgrade";
    }


    public IHcl2UpgradeCommandResponse StartProcess(IHcl2UpgradeCommandRequest request)
    {
        throw new NotImplementedException();
    }
}