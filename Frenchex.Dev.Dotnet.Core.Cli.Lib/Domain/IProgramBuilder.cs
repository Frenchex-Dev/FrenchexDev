using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public interface IProgramBuilder
{
    IProgram Build(
        Context context,
        Action<IServiceCollection> registerServices,
        Action<ILoggingBuilder> loggingConfiguration
    );
    
    IProgram Build(
        Context context,
        AsyncServiceScope asyncServiceScope,
        Action<ILoggingBuilder> loggingConfiguration
    );
}