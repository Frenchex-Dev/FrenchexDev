namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

public interface IEntrypointInfo
{
    string CommandLine { get; }

    string[] CommandLineArgs { get; }
}