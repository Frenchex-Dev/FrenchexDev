using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class Context : IContext
{
    public Context(
        string hostSettings,
        string appSettings,
        string prefix,
        string basePath
    )
    {
        HostSettings = hostSettings;
        AppSettings = appSettings;
        Prefix = prefix;
        BasePath = basePath;
    }

    public string HostSettings { get; }
    public string AppSettings { get; }
    public string Prefix { get; }
    public string BasePath { get; }
}