using Microsoft.Extensions.Configuration;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IHostConfigurationConfiguration
{
    void Configure(
        IContext context,
        IConfigurationBuilder hostConfiguration
    );
}