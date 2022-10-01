using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Facade;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Request;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Facade;

public class Hcl2UpgradeCommandFacade : IHcl2UpgradeCommandFacade
{
    public Hcl2UpgradeCommandFacade(
        IHcl2UpgradeCommand command,
        IHcl2UpgradeCommandRequestBuilderFactory requestBuilderFactory
    )
    {
        Command = command;
        RequestBuilderFactory = requestBuilderFactory;
    }

    public IHcl2UpgradeCommand Command { get; }
    public IHcl2UpgradeCommandRequestBuilderFactory RequestBuilderFactory { get; }

    public IHcl2UpgradeCommandRequestBuilder RequestBuilder => RequestBuilderFactory.Factory();

    public string GetCliCommandName()
    {
        return "fmt";
    }
}