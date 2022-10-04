using Frenchex.Dev.Dotnet.Core.Wrapping.Lib.Abstractions.Domain.Commands.Root.Response;
using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;

public interface IHcl2UpgradeCommandResponseBuilderFactory : IRootCommandResponseBuilderFactory
{
    IHcl2UpgradeCommandResponseBuilder Factory();
}