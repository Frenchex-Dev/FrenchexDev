using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Hcl2Upgrade.Response;
using Microsoft.Extensions.DependencyInjection;

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Hcl2Upgrade.Response;

public class Hcl2UpgradeCommandResponseBuilderFactory : IHcl2UpgradeCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public Hcl2UpgradeCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IHcl2UpgradeCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IHcl2UpgradeCommandResponseBuilder>();
    }
}