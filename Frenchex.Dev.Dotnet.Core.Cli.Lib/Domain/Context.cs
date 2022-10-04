using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class Context : IContext
{
    public Context(
        string hostSettings,
        string appSettings,
        string envVarPrefix,
        string basePath,
        string currentDomainBaseDirectory
    )
    {
        HostSettings = hostSettings;
        AppSettings = appSettings;
        EnvVarPrefix = envVarPrefix;
        BasePath = basePath;
        CurrentDomainBaseDirectory = currentDomainBaseDirectory;
    }

    public string HostSettings { get; }
    public string AppSettings { get; }
    public string EnvVarPrefix { get; }
    public string BasePath { get; }
    public string CurrentDomainBaseDirectory { get; set; }
}