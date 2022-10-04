namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IContext
{
    string HostSettings { get; }
    string AppSettings { get; }
    string Prefix { get; }
    string BasePath { get; }
}