#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Dotnet.Core.Cli.Lib.Abstractions.Domain;

#endregion

namespace Frenchex.Dev.Dotnet.Core.Cli.Lib.Domain;

public class SystemEnvironmentEntrypointInfo : IEntrypointInfo
{
    public string CommandLine => Environment.CommandLine;

    public string[] CommandLineArgs => Environment.GetCommandLineArgs();
}