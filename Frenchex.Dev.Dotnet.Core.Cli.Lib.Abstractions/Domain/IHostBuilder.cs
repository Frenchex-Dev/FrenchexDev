using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IHostBuilder
{
    IHost Build(
        IContext context,
        Action<IServiceCollection> servicesConfigurationLambda,
        Action<ILoggingBuilder> loggingConfigurationLambda
    );

    IHost Build(
        IContext context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfigurationLambda
    );
}