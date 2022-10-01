using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Request;

public class Hcl2UpgradeCommandRequest : IHcl2UpgradeCommandRequest
{
    public Hcl2UpgradeCommandRequest(IBaseCommandRequest @base)
    {
        Base = @base;
    }

    public IBaseCommandRequest Base { get; }
}