using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Request;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

public interface IHcl2UpgradeCommandRequestBuilderFactory : IRootCommandRequestBuilderFactory
{
    IHcl2UpgradeCommandRequestBuilder Factory();
}