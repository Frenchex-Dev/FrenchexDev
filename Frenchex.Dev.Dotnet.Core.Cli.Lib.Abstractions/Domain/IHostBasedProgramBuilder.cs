using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IHostBasedProgramBuilder
{
    IProgram Build(
        IContext context,
        Action<IServiceCollection> registerServices,
        Action<IServiceCollection> registerHostedServices,
        Action<ILoggingBuilder> loggingConfiguration
    );

    IProgram Build(
        IContext context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfiguration
    );
}