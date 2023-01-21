#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

// ReSharper disable UnusedMember.Global

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

#endregion

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