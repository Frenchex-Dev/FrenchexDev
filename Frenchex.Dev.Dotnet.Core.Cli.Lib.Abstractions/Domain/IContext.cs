namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IContext
{
    string HostSettings { get; }
    string AppSettings { get; }
    string EnvVarPrefix { get; }
    string BasePath { get; }
    string CurrentDomainBaseDirectory { get; set; }
}