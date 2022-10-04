// ReSharper disable UnusedMember.Global

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class SimpleEntrypointInfo : IEntrypointInfo
{
    public SimpleEntrypointInfo(string commandLine, string[] commandLineArgs)
    {
        CommandLine = commandLine ?? throw new ArgumentNullException(nameof(commandLine));
        CommandLineArgs = commandLineArgs ?? throw new ArgumentNullException(nameof(commandLineArgs));
    }

    public string CommandLine { get; }

    public string[] CommandLineArgs { get; }
}