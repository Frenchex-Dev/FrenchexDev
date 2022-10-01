using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Fmt.Request;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

public interface IHcl2UpgradeCommandRequestBuilder : IRootCommandRequestBuilder
{
    IHcl2UpgradeCommandRequest Build();
}