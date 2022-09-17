using Frenchex.Dev.Dotnet.Core.Cli.Lib.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class Builder : IBuilder
{
    public IProgram Build(
        Action<IServiceCollection> configureProgramServicesAction,
        Action<IServiceCollection> configureHostedServicesAction,
        Action<ILoggingBuilder> configureProgramLoggingAction,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string envVarPrefix,
        string appDomainDirectory
    )
    {
        var services = new ServiceCollection();

        new ServicesConfiguration()
            .ConfigureServices(services);

        var di = services.BuildServiceProvider();
        var scope = di.CreateAsyncScope();
        var scopedDi = scope.ServiceProvider;
        var programBuilder = scopedDi.GetRequiredService<IProgramBuilder>();

        var program = programBuilder.Build(
            new Context(
                Path.GetFullPath(hostSettingsJsonFilename, appDomainDirectory),
                Path.GetFullPath(appSettingsJsonFilename, appDomainDirectory),
                envVarPrefix,
                Directory.GetCurrentDirectory()
            ),
            configureProgramServicesAction,
            configureHostedServicesAction,
            configureProgramLoggingAction
        );

        return program;
    }

    public IProgram Build(
        IServiceCollection services,
        Action<ILoggingBuilder> configureProgramLoggingAction,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string envVarPrefix,
        string appDomainDirectory
    )
    {
        var di = services.BuildServiceProvider();
        var scope = di.CreateAsyncScope();
        var scopedDi = scope.ServiceProvider;
        var programBuilder = scopedDi.GetRequiredService<IProgramBuilder>();

        var program = programBuilder.Build(
            new Context(
                Path.GetFullPath(hostSettingsJsonFilename, appDomainDirectory),
                Path.GetFullPath(appSettingsJsonFilename, appDomainDirectory),
                envVarPrefix,
                Directory.GetCurrentDirectory()
            ),
            scope,
            configureProgramLoggingAction
        );

        return program;
    }
}