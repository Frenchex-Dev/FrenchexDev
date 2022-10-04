using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frenchex.Dev.OnSteroid.Cli.Lib.Domain.Program;

public interface IProgramBuilder
{
    public Task<IProgram> BuildAsync<T>(
        IServiceCollection serviceCollection,
        Action<IServiceCollection> registerServices,
        string hostSettingsJsonFilename,
        string appSettingsJsonFilename,
        string currentDomainBaseDirectory,
        string envVarPrefix,
        string basePath
    ) where T : class, IHostedService;
}