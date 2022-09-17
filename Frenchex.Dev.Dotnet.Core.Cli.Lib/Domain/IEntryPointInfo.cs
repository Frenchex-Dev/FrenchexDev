namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public interface IEntrypointInfo
{
    string CommandLine { get; }

    string[] CommandLineArgs { get; }
}