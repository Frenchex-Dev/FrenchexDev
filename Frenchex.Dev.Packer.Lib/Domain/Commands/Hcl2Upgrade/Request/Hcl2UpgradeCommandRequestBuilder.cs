using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Request;

public class Hcl2UpgradeCommandRequestBuilder : IHcl2UpgradeCommandRequestBuilder
{
    public Hcl2UpgradeCommandRequestBuilder(IBaseCommandRequestBuilder baseBuilder)
    {
        BaseBuilder = baseBuilder;
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IHcl2UpgradeCommandRequest Build()
    {
        return new Hcl2UpgradeCommandRequest(BaseBuilder.Build());
    }
}