using Frenchex.Dev.Dotnet.Cli.Lib.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public interface IBuilder
{
    public IProgram Build(
        Action<IServiceCollection> configureProgramServicesAction,
        Action<ILoggingBuilder> configureProgramLoggingAction,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string envVarPrefix,
        string appDomainDirectory
    );
}