
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IAppConfigurationConfiguration
{
    void ConfigureApp(
        IContext context,
        HostBuilderContext hostContext,
        IConfigurationBuilder appConfiguration
    );
}